using Model.EF;
using PerfumeStore_BrandNCountry.Common;
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
            var mems = (UserLogin)Session[CommonConstant.USER_SESSION];
            var listProduct = new List<favList>();
            var listIdProductFave = new List<favList>();
            if (mems != null)
            {
                listIdProductFave = db.favLists.Where(x => x.user_id == mems.userId).ToList();
                if (listIdProductFave != null && listIdProductFave.Count > 0)
                {
                    foreach (var item in listIdProductFave)
                    {
                        product Product = db.products.Find(item.product_id);
                        //create new favorite item
                        var itemProduct = new favList();
                        itemProduct.user_id = item.user_id;
                        itemProduct.product_id = item.product_id;
                        itemProduct.product = Product;
                        listProduct.Add(itemProduct);
                    }
                }
            }
            ViewBag.imgPath = imgPath;
            return View(listProduct);
        }

        public ActionResult AddItem(int productId)
        {
            var mems = (UserLogin)Session[CommonConstant.USER_SESSION];
            if(mems != null)
            {
                var model = new favList();
                //create new favorite item
                var item = new FavItem();
                model.user_id = mems.userId;
                model.product_id = productId;
                db.favLists.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return Redirect("/");
            //product Product = db.products.Find(productId);
            ////Get favorite from session
            //var fav = Session[FavListSession];
            //if (fav != null)
            //{
            //    var list = (List<FavItem>)fav;
            //    //create new favorite item
            //    var item = new FavItem();
            //    item.Product = Product;
            //    list.Add(item);
            //    //Add to Session
            //    Session[FavListSession] = list;
            //}
            //else
            //{
            //    //create new favorite item
            //    var item = new FavItem();
            //    item.Product = Product;
            //    var list = new List<FavItem>();
            //    list.Add(item);
            //    //assign to session
            //    Session[FavListSession] = list;
            //}
            
        }



        public ActionResult DeleteItem(int productId)
        {
            var mems = (UserLogin)Session[CommonConstant.USER_SESSION];
            if (mems != null)
            {
                var flag = db.favLists.Where(x => x.product_id == productId && x.user_id == mems.userId).FirstOrDefault();
                if(flag != null)
                {
                    db.favLists.Remove(flag);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            //Get cart from session
            //var fav = Session[FavListSession];
            //var list = (List<FavItem>)fav;

            //list.RemoveAll(x => x.Product.product_id == productId);
            ////assign to session
            //Session[FavListSession] = list;
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
