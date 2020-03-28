using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PerfumeStore_BrandNCountry.Controllers
{
    public class HomeController : Controller
    {
        private PerfumeStoreDbContext db = new PerfumeStoreDbContext();
        private string imgDir = "/Assets/img/product/single-product";

        public ActionResult Index()
        {
            var productList = db.products.Include(p => p.brand).Include(p => p.category).Include(p => p.productImgs);
            ViewBag.imgPath = imgDir;
            return View(productList.ToList());
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