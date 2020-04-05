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
    public class CountriesController : BaseController
    {
        private PerfumeStoreDbContext db = new PerfumeStoreDbContext();

        // GET: Admin/Countries
        [UserAuthorize]
        public ActionResult Index()
        {
            return View(db.countries.ToList());
        }
        [UserAuthorize]
        // GET: Admin/Countries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            country country = db.countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }
        [UserAuthorize]
        // GET: Admin/Countries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [UserAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "country_id,country_name,country_status,country_createdAt")] country country)
        {
            if (ModelState.IsValid)
            {
                country.country_createdAt = DateTime.Now;
                db.countries.Add(country);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(country);
        }
        [UserAuthorize]
        // GET: Admin/Countries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            country country = db.countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Admin/Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [UserAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "country_id,country_name,country_status,country_createdAt")] country country)
        {
            if (ModelState.IsValid)
            {
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(country);
        }

        // GET: Admin/Countries/Delete/5
        [UserAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            country country = db.countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Admin/Countries/Delete/5
        [UserAuthorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            country country = db.countries.Find(id);
            db.countries.Remove(country);
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
