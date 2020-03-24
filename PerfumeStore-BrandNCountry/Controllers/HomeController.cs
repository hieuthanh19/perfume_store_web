using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerfumeStore_BrandNCountry.Controllers
{
    public class HomeController : Controller
    {
        private PerfumeStoreDbContext db = new PerfumeStoreDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Store(int categoryId)
        {
            var products = db.products.Include(p => p.brand).Include(p => p.category);
            var finalList = products;
            if (categoryId != -1)
            {
                finalList = products.Where(p => p.category_id == categoryId && p.product_status != 0);
            }
            else
                finalList = products.Where(p => p.product_status != 0);

            return View(finalList.ToList());
        }

        [ChildActionOnly]
        public ActionResult CategoryList()
        {
            return View(db.categories.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}