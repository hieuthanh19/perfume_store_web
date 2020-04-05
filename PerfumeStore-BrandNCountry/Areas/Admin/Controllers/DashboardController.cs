using PerfumeStore_BrandNCountry.Areas.Admin.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerfumeStore_BrandNCountry.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        // GET: Admin/Home
        [UserAuthorize]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Denied()
        {
            return View();
        }
    }
}