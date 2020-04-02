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


    public class CartController : Controller
    {
        private PerfumeStoreDbContext db = new PerfumeStoreDbContext();
        private const string CartSession = "CartSession";
        private const string imgPath = "/Assets/img/product/single-product";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            //if session already has cart
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            ViewBag.imgPath = imgPath;
            ViewBag.categories = db.categories.Where(c => c.category_status == 1);
            return View(list);
        }

      

        
        public ActionResult AddItem(int productId, int quantity)
        {
            product Product = db.products.Find(productId);
            //Get cart from session
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;

                if (list.Exists(x => x.Product.product_id == productId))
                {
                    // Find product and increase quantity
                    foreach (var item in list)
                    {
                        if (item.Product.product_id == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //create new cart item
                    var item = new CartItem();
                    item.Product = Product;
                    item.Quantity = quantity;
                    list.Add(item);
                }

                //Add to Session
                Session[CartSession] = list;
            }
            else
            {
                //create new cart item
                var item = new CartItem();
                item.Product = Product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //assign to session
                Session[CartSession] = list;

            }

            return RedirectToAction("Index");

        }


        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];
            var resultStatus = true;
            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.product_id == item.Product.product_id);
                if (jsonItem != null)
                {
                    if ( item.Product.product_quantity >= jsonItem.Quantity)
                    item.Quantity = jsonItem.Quantity;
                    else
                    {
                        resultStatus = false;
                    }
                }
               

            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = resultStatus
            });
        }

        public ActionResult DeleteItem(int productId)
        {
            //Get cart from session
            var cart = Session[CartSession];
            var list = (List<CartItem>)cart;

            list.RemoveAll(x => x.Product.product_id == productId);
            //assign to session
            Session[CartSession] = list;
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAll()
        {
            var list = new List<CartItem>();
            Session[CartSession] = list;
            return RedirectToAction("Index");
        }
    }
}