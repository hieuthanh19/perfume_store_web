using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerfumeStore_BrandNCountry.Controllers
{
    public class SearchController : Controller
    {
        private PerfumeStoreDbContext db = new PerfumeStoreDbContext();
        private string imgDir = "/Assets/img/product/single-product";

        // GET: Search
        public ActionResult searchPage(string searchString = "___")
        {
            var pr = from p in db.products select p;
            pr = db.products.Where(p => p.product_name.Contains(searchString));
            ViewBag.imgPath = imgDir;
            ViewBag.categories = db.categories.Where(c => c.category_status == 1);
            return View(pr.ToList());
        }

    }
}