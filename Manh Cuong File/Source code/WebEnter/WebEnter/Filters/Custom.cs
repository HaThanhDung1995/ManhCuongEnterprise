using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEnter.Models;
using WebEnter.Utils;

namespace WebEnter.Filters
{
    public class CustomAttribute : AuthorizeAttribute
    {
        public string PermissionNames;

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var account = XSession.Master;
            var Permission = PermissionNames.Split('|').ToList();
            if (account != null)
            {
                try
                {
                    using (var dataContext = new DataContext())
                    {
                        //var roles = dataContext.AccountRoles.Where(q => q.UserID == account.AccountID).Select(q => q.RoleKey).ToList();
                        var roles = dataContext.MasterRoles.Where(q => q.MasterId == account.Id).Select(q => q.Role.RoleName)
                            .ToList();
                        foreach (var role in roles)
                        {
                            foreach (var item in Permission)
                            {
                                if (item.Trim().ToLower() == role.Trim().ToLower())
                                    return true;
                            }

                        }
                    }
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var router = HttpContext.Current.Request.Url.AbsolutePath;
            filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "Manager", Action = "Login", ReturnUrl = router, Message = "You do not have sufficient permissions to access this page !" }));

        }
    }
}