using Model.DAO;
using Model.EF;
using PerfumeStore_BrandNCountry.Common;
using PerfumeStore_BrandNCountry.Models;
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
            ViewBag.categories = db.categories.Where(c => c.category_status == 1);
            return View(productList.ToList());
        }       

        
      
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItem>();
            //if session already has cart
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Detail(int id)
        {
            var product = new ProductDAO().GetProduct(id);
            ViewBag.imgPath = imgDir;
            ViewBag.Message = "Your detail page.";
            ViewBag.id = id;
            return View(product);
        }
    }
}