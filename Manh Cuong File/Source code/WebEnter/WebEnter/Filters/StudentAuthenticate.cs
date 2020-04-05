using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEnter.Utils;

namespace WebEnter.Filters
{
    public class StudentAuthenticateAttribute : AuthorizeAttribute

    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var account = XSession.Student;

            if (account != null)
            {
                return true;
            }

            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var router = HttpContext.Current.Request.Url.AbsolutePath;
            filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "Student", Action = "Login", ReturnUrl = router, Message = "You do not have sufficient permissions to access this page !" }));

        }
    }
}