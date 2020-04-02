using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerfumeStore_BrandNCountry.Controllers
{
    public class ContactController : Controller
    {
        private PerfumeStoreDbContext db = new PerfumeStoreDbContext();
        // GET: Contact
        public ActionResult Index()
        {
          
            return View();
        }
    }
}