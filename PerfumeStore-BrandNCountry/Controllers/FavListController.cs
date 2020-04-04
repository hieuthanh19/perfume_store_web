using Model.EF;
using PerfumeStore_BrandNCountry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PerfumeStore_BrandNCountry.Controllers
{
    public class FavListController : Controller
    {
        private PerfumeStoreDbContext db = new PerfumeStoreDbContext();
        private const string FavListSession = "FavListSession";
        private const string imgPath = "/Assets/img/product/single-product";
        // GET: FavList
        public ActionResult Index()
        {
            //var fav = Session[FavListSession];
            //var list = new List<FavItem>();
            ////if session already has cart
            //if (fav != null)
            //{
            //    list = (List<FavItem>)fav;
            //}
            //ViewBag.imgPath = imgPath;
            //find favlist from user
            var list = db.users.Find(4).favLists.ToList();            
            ViewBag.imgPath = imgPath;
            return View(list);
        }

        public ActionResult AddItem(int productId)
        {
            product Product = db.products.Find(productId);
            //Get favorite from session
            var fav = Session[FavListSession];
            if (fav != null)
            {
                var list = (List<FavItem>)fav;
                //create new favorite item
                var item = new FavItem();
                item.Product = Product;
                list.Add(item);
                //Add to Session
                Session[FavListSession] = list;
            }
            else
            {
                //create new favorite item
                var item = new FavItem();
                item.Product = Product;
                var list = new List<FavItem>();
                list.Add(item);
                //assign to session
                Session[FavListSession] = list;
            }
            return RedirectToAction("Index");
        }



        public ActionResult DeleteItem(int productId)
        {
            //Get cart from session
            var fav = Session[FavListSession];
            var list = (List<FavItem>)fav;

            list.RemoveAll(x => x.Product.product_id == productId);
            //assign to session
            Session[FavListSession] = list;
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAll()
        {
            var list = new List<FavItem>();
            Session[FavListSession] = list;
            return RedirectToAction("Index");
        }
    }

}
