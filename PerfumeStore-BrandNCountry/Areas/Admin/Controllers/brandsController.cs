using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using PerfumeStore_BrandNCountry.Areas.Admin.Code;

namespace PerfumeStore_BrandNCountry.Areas.Admin.Controllers
{
    public class brandsController : BaseController
    {
        private PerfumeStoreDbContext db = new PerfumeStoreDbContext();

        // GET: Admin/brands
        [UserAuthorize]
        public ActionResult Index()
        {
            var brands = db.brands.Include(b => b.country);
            return View(brands.ToList());
        }

        // GET: Admin/brands/Details/5
        [UserAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            brand brand = db.brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // GET: Admin/brands/Create
        [UserAuthorize]
        public ActionResult Create()
        {
            ViewBag.country_id = new SelectList(db.countries, "country_id", "country_name");
            return View();
        }

        // POST: Admin/brands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [UserAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "brand_id,brand_name,country_id,brand_status, brand_createdAt")] brand brand)
        {
            if (ModelState.IsValid)
            {
                brand.brand_createdAt = DateTime.Now;
                db.brands.Add(brand);
                db.SaveChanges();
                return RedirectToAction("Index");              
                
            }

            ViewBag.country_id = new SelectList(db.countries, "country_id", "country_name", brand.country_id);
            return View(brand);
        }

        // GET: Admin/brands/Edit/5
        [UserAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            brand brand = db.brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            ViewBag.country_id = new SelectList(db.countries, "country_id", "country_name", brand.country_id);
            return View(brand);
        }

        // POST: Admin/brands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [UserAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "brand_id,brand_name,country_id,brand_createdAt,brand_status")] brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.country_id = new SelectList(db.countries, "country_id", "country_name", brand.country_id);
            return View(brand);
        }

        // GET: Admin/brands/Delete/5
        [UserAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            brand brand = db.brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: Admin/brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [UserAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            brand brand = db.brands.Find(id);
            db.brands.Remove(brand);
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
