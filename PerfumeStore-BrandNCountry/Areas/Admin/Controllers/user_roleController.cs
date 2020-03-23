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
    public class user_roleController : Controller
    {
        private PerfumeStoreDbContext db = new PerfumeStoreDbContext();

        // GET: Admin/user_role
        public ActionResult Index()
        {
            return View(db.user_role.ToList());
        }

        // GET: Admin/user_role/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_role user_role = db.user_role.Find(id);
            if (user_role == null)
            {
                return HttpNotFound();
            }
            return View(user_role);
        }

        // GET: Admin/user_role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/user_role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "role_id,role_name,role_status")] user_role user_role)
        {
            if (ModelState.IsValid)
            {
                db.user_role.Add(user_role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_role);
        }

        // GET: Admin/user_role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_role user_role = db.user_role.Find(id);
            if (user_role == null)
            {
                return HttpNotFound();
            }
            return View(user_role);
        }

        // POST: Admin/user_role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "role_id,role_name,role_status")] user_role user_role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_role);
        }

        // GET: Admin/user_role/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_role user_role = db.user_role.Find(id);
            if (user_role == null)
            {
                return HttpNotFound();
            }
            return View(user_role);
        }

        // POST: Admin/user_role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user_role user_role = db.user_role.Find(id);
            db.user_role.Remove(user_role);
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
