using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PerfumeStore_BrandNCountry.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        public static HttpContextBase HttpContextBase { get; set; }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (Common.AdminLogin)Session[Common.CommonConstant.ADMIN_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new {area = "Admin", controller = "Login", action = "Index" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}