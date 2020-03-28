using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using System.IO;
using System.Configuration;
using PerfumeStore_BrandNCountry.Common;

namespace PerfumeStore_BrandNCountry.Areas.Admin.Controllers
{
    public class productsController : Controller
    {
        private PerfumeStoreDbContext db = new PerfumeStoreDbContext();
        private CommonUtils commonUtils = new CommonUtils();
        private string imgDir = "/Assets/img/product/single-product";

        // GET: Admin/products
        public ActionResult Index()
        {

            var products = db.products.Include(p => p.brand).Include(p => p.category).Include(p => p.productImgs);
            //ViewBag.imgPath = Server.MapPath("~/Assets/img/product/single-product/");
            ViewBag.imgPath = imgDir;
            return View(products.ToList());
        }

        // GET: Admin/products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.imgPath = imgDir;
            ViewBag.statusText = commonUtils.getProductStatusTextFromProductStatusList(product.product_status);
            return View(product);
        }

        // GET: Admin/products/Create
        public ActionResult Create()
        {
            ViewBag.brand_id = new SelectList(db.brands, "brand_id", "brand_name");
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name");
                       
            ViewBag.product_status = new SelectList(commonUtils.getProductStatusList(), "Value", "Text");
            return View();
        }

        // POST: Admin/products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductNProductImgDAO model)
        {
            if (model.checkIsImage(model.imgFile.FileName))
            {
                if (ModelState.IsValid)
                {
                    //product 
                    model.Product.product_createdAt = DateTime.Now;
                    model.Product.product_updatedAt = DateTime.Now;
                    int status = int.Parse(Request.Form["product_status"]);
                    int category_id = int.Parse(Request.Form["category_id"]);
                    int brand_id = int.Parse(Request.Form["brand_id"]);
                    model.Product.product_status = status;
                    model.Product.category_id = category_id;
                    model.Product.brand_id = brand_id;
                    db.products.Add(model.Product);
                    db.SaveChanges();
                    //check image type

                    //save image 
                    string FileName = Path.GetFileNameWithoutExtension(model.imgFile.FileName);
                    //To Get File Extension  
                    string FileExtension = Path.GetExtension(model.imgFile.FileName);
                    //Add Current Date To Attached File Name  
                    FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
                    //string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();
                    string SavePath = Server.MapPath("~/Assets/img/product/single-product/" + model.Product.product_id + "/");
                    Directory.CreateDirectory(SavePath);
                    model.imgFile.SaveAs(SavePath + FileName);

                    //set product img data   
                    model.productImg = new productImg();
                    model.productImg.img_path = FileName;
                    model.productImg.product = model.Product;

                    //set status to active
                    model.productImg.img_status = 1;
                    db.productImgs.Add(model.productImg);

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("imgFile", "Only Image files allowed.");
            }

            ViewBag.brand_id = new SelectList(db.brands, "brand_id", "brand_name", model.Product.brand_id);
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", model.Product.category_id);            
            ViewBag.product_status = new SelectList(commonUtils.getProductStatusList(), "Value", "Text", model.Product.product_status);
            return View(model);
        }

        // GET: Admin/products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductNProductImgDAO productNProductImgDAO = new ProductNProductImgDAO();
            productNProductImgDAO.Product = db.products.Find(id);
            productNProductImgDAO.productImg = db.productImgs.Where(proImg => proImg.product_id == id).First();
            if (productNProductImgDAO.Product == null)
            {
                return HttpNotFound();
            }

            ViewBag.brand_id = new SelectList(db.brands, "brand_id", "brand_name", productNProductImgDAO.Product.brand_id);
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", productNProductImgDAO.Product.category_id);
            //List<string> product_statusList = new List<string> { "Locked", "In stock", "Out of stock" };
            ViewBag.product_status = new SelectList(commonUtils.getProductStatusList(), "Value", "Text", productNProductImgDAO.Product.product_status);

            ViewBag.imgPath = imgDir;
            return View(productNProductImgDAO);
        }

        // POST: Admin/products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductNProductImgDAO model)
        {
            ModelState.Clear();
            //check image
            if (model.imgFile != null)
            {
                if (!model.checkIsImage(model.imgFile.FileName))
                {
                    ModelState.AddModelError("imgFile", "Only Image files allowed.");
                }
            }

            if (ModelState.IsValid)
            {
                //PRODUCT
                //get data
                int status = int.Parse(Request.Form["product_status"]);
                int category_id = int.Parse(Request.Form["category_id"]);
                int brand_id = int.Parse(Request.Form["brand_id"]);
                //set data
                model.Product.product_status = status;
                model.Product.category_id = category_id;
                model.Product.brand_id = brand_id;                
                model.Product.product_updatedAt = DateTime.Now;
                db.Entry(model.Product).State = EntityState.Modified;

                if (model.imgFile != null)
                {
                    //save image 
                    string FileName = Path.GetFileNameWithoutExtension(model.imgFile.FileName);
                    //To Get File Extension  
                    string FileExtension = Path.GetExtension(model.imgFile.FileName);
                    //Add Current Date To Attached File Name  
                    FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + FileName.Trim() + FileExtension;
                    //string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();
                    string SavePath = Server.MapPath("~/Assets/img/product/single-product/" + model.Product.product_id + "/");
                    Directory.CreateDirectory(SavePath);
                    model.imgFile.SaveAs(SavePath + FileName);

                    //set product img data                       
                    model.productImg.img_path = FileName;
                    model.productImg.product = model.Product;                                      
                    model.productImg.img_status = 1;
                    //add image - remember to remove productImg in Edit
                    //int id = model.productImg.product_id;
                    //productImg productImg = db.productImgs.Where(pi => pi.product_id == model.Product.product_id).First();
                    //if (productImg == null)
                    //{
                    //    db.productImgs.Add(model.productImg);
                    //}
                    //else
                    //{
                    //    db.Entry(productImg).State = EntityState.Detached;

                    //}
                    db.Entry(model.productImg).State = EntityState.Modified;

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.brand_id = new SelectList(db.brands, "brand_id", "brand_name", model.Product.brand_id);
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", model.Product.category_id);
            ViewBag.product_status = new SelectList(commonUtils.getProductStatusList(), "Value", "Text", model.Product.product_status);
            return View(model);
        }

        // GET: Admin/products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.imgPath = imgDir;
            ViewBag.statusText = commonUtils.getProductStatusTextFromProductStatusList(product.product_status);
            return View(product);
        }

        // POST: Admin/products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.products.Find(id);
            db.productImgs.Remove(product.productImgs.First());
            db.products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
