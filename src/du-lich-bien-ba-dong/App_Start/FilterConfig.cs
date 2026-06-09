using System.Web;
using System.Web.Mvc;

namespace du_lich_bien_ba_dong
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
