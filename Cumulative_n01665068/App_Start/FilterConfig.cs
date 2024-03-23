using System.Web;
using System.Web.Mvc;

namespace Cumulative_n01665068
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
