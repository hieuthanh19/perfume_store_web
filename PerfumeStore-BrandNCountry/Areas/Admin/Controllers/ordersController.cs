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
    public class ordersController : Controller
    {
        private PerfumeStoreDbContext db = new PerfumeStoreDbContext();

        // GET: Admin/orders
        public ActionResult Index()
        {
            var orders = db.orders.Include(o => o.deliveryMethod).Include(o => o.paymentMethod).Include(o => o.user);
            return View(orders.ToList());
        }

        // GET: Admin/orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Admin/orders/Create
        public ActionResult Create()
        {
            ViewBag.deliveryMethod_id = new SelectList(db.deliveryMethods, "delivery_id", "delivery_name");
            ViewBag.order_paymentMethod = new SelectList(db.paymentMethods, "payment_id", "payment_name");
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_username");
            return View();
        }

        // POST: Admin/orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "order_id,user_id,order_paymentStatus,order_handledBy,order_status,order_paymentMethod,order_totalCost,order_receiverName,order_receiverAddress,order_receiverPhone,order_receiverEmail,deliveryMethod_id,order_deliveryStatus,order_createdAt,order_updatedAt,order_deliveredAt")] order order)
        {
            if (ModelState.IsValid)
            {
                db.orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.deliveryMethod_id = new SelectList(db.deliveryMethods, "delivery_id", "delivery_name", order.deliveryMethod_id);
            ViewBag.order_paymentMethod = new SelectList(db.paymentMethods, "payment_id", "payment_name", order.order_paymentMethod);
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_username", order.user_id);
            return View(order);
        }

        // GET: Admin/orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.deliveryMethod_id = new SelectList(db.deliveryMethods, "delivery_id", "delivery_name", order.deliveryMethod_id);
            ViewBag.order_paymentMethod = new SelectList(db.paymentMethods, "payment_id", "payment_name", order.order_paymentMethod);
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_username", order.user_id);
            return View(order);
        }

        // POST: Admin/orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "order_id,user_id,order_paymentStatus,order_handledBy,order_status,order_paymentMethod,order_totalCost,order_receiverName,order_receiverAddress,order_receiverPhone,order_receiverEmail,deliveryMethod_id,order_deliveryStatus,order_createdAt,order_updatedAt,order_deliveredAt")] order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.deliveryMethod_id = new SelectList(db.deliveryMethods, "delivery_id", "delivery_name", order.deliveryMethod_id);
            ViewBag.order_paymentMethod = new SelectList(db.paymentMethods, "payment_id", "payment_name", order.order_paymentMethod);
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_username", order.user_id);
            return View(order);
        }

        // GET: Admin/orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Admin/orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order order = db.orders.Find(id);
            db.orders.Remove(order);
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
