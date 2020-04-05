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
            var productList = db.products.Where(p => p.product_status == 1).Include(p => p.brand).Include(p => p.category).Include(p => p.productImgs);
            ViewBag.imgPath = imgDir;
          
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

        [ChildActionOnly]
        public PartialViewResult HeaderFav()
        {
            //var fav = Session[CommonConstant.FavSession];
            ////if session already has cart
            //if (fav != null)
            //{
            //    list = (list<favitem>)fav;
            //}

            //find favlist of user with userid = 4
            var mems = (UserLogin)Session[CommonConstant.USER_SESSION];
            var list = new List<favList>();
            if (mems != null)
            {
                list = db.favLists.Where(x => x.user_id == mems.userId).ToList();
            }
            return PartialView(list);
        }

        [ChildActionOnly]
        public PartialViewResult FooterCategory()
        {
            var categories = db.categories.Where(c => c.category_status == 1);
            return PartialView(categories);
        }
        public JsonResult AddToFavoriteList(int productid)
        {
            var mems = (UserLogin)Session[CommonConstant.USER_SESSION];
            if(mems == null)
            {
                return Json(new
                {
                    status = false,
                    msg = "Please sign in"
                }, JsonRequestBehavior.AllowGet);
            }
            var listExist = db.favLists.Where(x => x.user_id == mems.userId && x.product_id == productid).FirstOrDefault();
            if(listExist != null)
            {
                return Json(new
                {
                    status = false,
                    msg = "Product is exits on favorite list"
                }, JsonRequestBehavior.AllowGet);
            }
            var model = new favList();
            model.product_id = productid;
            model.user_id = mems.userId;
            db.favLists.Add(model);
            db.SaveChanges();
            return Json(new
            {
                status = true,
                msg = "Add product on favorite list success"
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}