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
    public class usersController : BaseController
    {
        private PerfumeStoreDbContext db = new PerfumeStoreDbContext();
        [UserAuthorize]
        // GET: Admin/users
        public ActionResult Index()
        {
            var users = db.users.Include(u => u.user_role);
            return View(users.ToList());
        }
        [UserAuthorize]
        // GET: Admin/users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [UserAuthorize]
        // GET: Admin/users/Create
        public ActionResult Create()
        {
            ViewBag.user_roleId = new SelectList(db.user_role, "role_id", "role_name");
            return View();
        }

        // POST: Admin/users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [UserAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,user_username,user_password,user_roleId,user_fullName,user_address,user_phone,user_email,user_avartar,user_createdAt,user_status")] user user)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_roleId = new SelectList(db.user_role, "role_id", "role_name", user.user_roleId);
            return View(user);
        }
        [UserAuthorize]
        // GET: Admin/users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_roleId = new SelectList(db.user_role, "role_id", "role_name", user.user_roleId);
            return View(user);
        }

        // POST: Admin/users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [UserAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,user_username,user_password,user_roleId,user_fullName,user_address,user_phone,user_email,user_avartar,user_createdAt,user_status")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_roleId = new SelectList(db.user_role, "role_id", "role_name", user.user_roleId);
            return View(user);
        }
        [UserAuthorize]
        // GET: Admin/users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/users/Delete/5
        [HttpPost, ActionName("Delete")]
        [UserAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
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
