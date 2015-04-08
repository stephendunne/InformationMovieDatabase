using System.Web;
using System.Web.Mvc;

namespace MVCs00130835_CA2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}