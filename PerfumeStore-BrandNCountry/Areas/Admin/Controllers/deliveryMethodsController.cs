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
    public class deliveryMethodsController : Controller
    {
        private PerfumeStoreDbContext db = new PerfumeStoreDbContext();

        // GET: Admin/deliveryMethods
        public ActionResult Index()
        {
            return View(db.deliveryMethods.ToList());
        }

        // GET: Admin/deliveryMethods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            deliveryMethod deliveryMethod = db.deliveryMethods.Find(id);
            if (deliveryMethod == null)
            {
                return HttpNotFound();
            }
            return View(deliveryMethod);
        }

        // GET: Admin/deliveryMethods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/deliveryMethods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "delivery_id,delivery_name,delivery_description,delivery_status")] deliveryMethod deliveryMethod)
        {
            if (ModelState.IsValid)
            {
                db.deliveryMethods.Add(deliveryMethod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliveryMethod);
        }

        // GET: Admin/deliveryMethods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            deliveryMethod deliveryMethod = db.deliveryMethods.Find(id);
            if (deliveryMethod == null)
            {
                return HttpNotFound();
            }
            return View(deliveryMethod);
        }

        // POST: Admin/deliveryMethods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "delivery_id,delivery_name,delivery_description,delivery_status")] deliveryMethod deliveryMethod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryMethod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deliveryMethod);
        }

        // GET: Admin/deliveryMethods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            deliveryMethod deliveryMethod = db.deliveryMethods.Find(id);
            if (deliveryMethod == null)
            {
                return HttpNotFound();
            }
            return View(deliveryMethod);
        }

        // POST: Admin/deliveryMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            deliveryMethod deliveryMethod = db.deliveryMethods.Find(id);
            db.deliveryMethods.Remove(deliveryMethod);
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
