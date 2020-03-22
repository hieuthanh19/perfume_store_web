using System.Web;
using System.Web.Mvc;

namespace PerfumeStore_BrandNCountry
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
