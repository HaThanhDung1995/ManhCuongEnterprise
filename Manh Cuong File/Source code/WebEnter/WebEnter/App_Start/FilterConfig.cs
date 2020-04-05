using System.Web;
using System.Web.Mvc;
using WebEnter.Filters;

namespace WebEnter
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
//            filters.Add(new AuthenticateAttribute());
        }
    }
}
