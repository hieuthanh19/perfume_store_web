using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace PerfumeStore_BrandNCountry.Areas.Admin.Controllers
{
    public class productImgsController : Controller
    {
        private PerfumeStoreDbContext db = new PerfumeStoreDbContext();

        // GET: Admin/productImgs
        public ActionResult Index()
        {
            var productImgs = db.productImgs.Include(p => p.product);
            return View(productImgs.ToList());
        }

        // GET: Admin/productImgs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productImg productImg = db.productImgs.Find(id);
            if (productImg == null)
            {
                return HttpNotFound();
            }
            return View(productImg);
        }

        // GET: Admin/productImgs/Create
        public ActionResult Create()
        {
            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name");
            return View();
        }

        // POST: Admin/productImgs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "img_id,product_id,img_path,img_status")] productImg productImg)
        {
            if (ModelState.IsValid)
            {
                db.productImgs.Add(productImg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name", productImg.product_id);
            return View(productImg);
        }

        // GET: Admin/productImgs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productImg productImg = db.productImgs.Find(id);
            if (productImg == null)
            {
                return HttpNotFound();
            }
            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name", productImg.product_id);
            return View(productImg);
        }

        // POST: Admin/productImgs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "img_id,product_id,img_path,img_status")] productImg productImg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productImg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name", productImg.product_id);
            return View(productImg);
        }

        // GET: Admin/productImgs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productImg productImg = db.productImgs.Find(id);
            if (productImg == null)
            {
                return HttpNotFound();
            }
            return View(productImg);
        }

        // POST: Admin/productImgs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productImg productImg = db.productImgs.Find(id);
            db.productImgs.Remove(productImg);
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
