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
    public class orderItemsController : Controller
    {
        private PerfumeStoreDbContext db = new PerfumeStoreDbContext();

        // GET: Admin/orderItems
        public ActionResult Index()
        {
            var orderItems = db.orderItems.Include(o => o.order).Include(o => o.product);
            return View(orderItems.ToList());
        }

        // GET: Admin/orderItems/Details/5
        public ActionResult Details(int? id1, int id2)
        {
            if (id1 == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderItem orderItem = db.orderItems.Find(id1,id2);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            return View(orderItem);
        }

        // GET: Admin/orderItems/Create
        public ActionResult Create()
        {
            ViewBag.order_id = new SelectList(db.orders, "order_id", "order_receiverName");
            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name");
            return View();
        }

        // POST: Admin/orderItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "order_id,product_id,orderItem_quantity,product_price")] orderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                db.orderItems.Add(orderItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.order_id = new SelectList(db.orders, "order_id", "order_receiverName", orderItem.order_id);
            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name", orderItem.product_id);
            return View(orderItem);
        }

        // GET: Admin/orderItems/Edit/5
        public ActionResult Edit(int? id1, int id2)
        {
            if (id1 == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderItem orderItem = db.orderItems.Find(id1, id2);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.order_id = new SelectList(db.orders, "order_id", "order_receiverName", orderItem.order_id);
            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name", orderItem.product_id);
            return View(orderItem);
        }

        // POST: Admin/orderItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "order_id,product_id,orderItem_quantity,product_price")] orderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.order_id = new SelectList(db.orders, "order_id", "order_receiverName", orderItem.order_id);
            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name", orderItem.product_id);
            return View(orderItem);
        }

        // GET: Admin/orderItems/Delete/5
        public ActionResult Delete(int? id1, int id2)
        {
            if (id1 == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderItem orderItem = db.orderItems.Find(id1, id2);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            return View(orderItem);
        }

        // POST: Admin/orderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id1, int id2)
        {
            orderItem orderItem = db.orderItems.Find(id1, id2);
            db.orderItems.Remove(orderItem);
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
