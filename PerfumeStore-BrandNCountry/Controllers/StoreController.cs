using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Model.DAO;

namespace PerfumeStore_BrandNCountry.Controllers
{
    public class StoreController : Controller
    {
        private PerfumeStoreDbContext db = new PerfumeStoreDbContext();
        private string imgDir = "/Assets/img/product/single-product";
        // GET: Store
        public ActionResult Index(int? pageNum, string search, int? sort, int? categoryId, int? brandId, int? volumeStart, int? volumeEnd, int? productsPerPage)
        {
            StoreDAO storeDAO = new StoreDAO(pageNum, search, sort, categoryId, brandId, volumeStart, volumeEnd, productsPerPage);
            ViewBag.brands = db.brands.Where(b => b.brand_status == 1);
            ViewBag.categories = db.categories.Where(c => c.category_status == 1);           
            ViewBag.imgPath = imgDir;
            ViewBag.storeDAO = storeDAO;
            return View(storeDAO.sortedProductList);
        }

        /// <summary>
        /// Generate view with all product 
        /// </summary>
        /// <returns></returns>
        public ActionResult Store()
        {
            var products = db.products.Include(p => p.brand).Include(p => p.category).Include(p => p.productImgs);
            return View(products.ToList());
        }

        /// <summary>
        /// Generate view with category name as parameter
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public ActionResult Store(string categoryName)
        {
            int categoryId = -1;
            categoryId = db.categories.Where(c => c.category_status == 1 && c.category_name.ToLower().Equals(categoryName.ToLower())).First().category_id;
            //if category not found
            if (categoryId == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var products = db.products.Where(p => p.category_id == categoryId && p.product_status != 0).Include(p => p.brand).Include(p => p.category).Include(p => p.productImgs);
            return View(products.ToList());
        }
    }
}