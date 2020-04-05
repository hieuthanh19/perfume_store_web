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
    public class paymentMethodsController : BaseController
    {
        private PerfumeStoreDbContext db = new PerfumeStoreDbContext();

        // GET: Admin/paymentMethods
        [UserAuthorize]
        public ActionResult Index()
        {
            return View(db.paymentMethods.ToList());
        }

        // GET: Admin/paymentMethods/Details/5
        [UserAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paymentMethod paymentMethod = db.paymentMethods.Find(id);
            if (paymentMethod == null)
            {
                return HttpNotFound();
            }
            return View(paymentMethod);
        }

        // GET: Admin/paymentMethods/
        [UserAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/paymentMethods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [UserAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "payment_id,payment_name,payment_description,payment_status")] paymentMethod paymentMethod)
        {
            if (ModelState.IsValid)
            {
                db.paymentMethods.Add(paymentMethod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paymentMethod);
        }

        // GET: Admin/paymentMethods/Edit/5
        [UserAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paymentMethod paymentMethod = db.paymentMethods.Find(id);
            if (paymentMethod == null)
            {
                return HttpNotFound();
            }
            return View(paymentMethod);
        }

        // POST: Admin/paymentMethods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [UserAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "payment_id,payment_name,payment_description,payment_status")] paymentMethod paymentMethod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentMethod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paymentMethod);
        }

        // GET: Admin/paymentMethods/Delete/5
        [UserAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paymentMethod paymentMethod = db.paymentMethods.Find(id);
            if (paymentMethod == null)
            {
                return HttpNotFound();
            }
            return View(paymentMethod);
        }

        // POST: Admin/paymentMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [UserAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            paymentMethod paymentMethod = db.paymentMethods.Find(id);
            db.paymentMethods.Remove(paymentMethod);
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
