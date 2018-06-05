using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CakeMaker_v4.Controllers
{
    public class AdminOrderDetailController : Controller
    {
        CakeMakerContext db = new CakeMakerContext();
        // GET: AdminOrderDetail
        public ActionResult Index()
        {
            return View(db.OrderDetails.ToList());
        }

        // GET: AdminOrderDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }

            return View(orderDetail);
        }

        // GET: AdminOrderDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminOrderDetail/Create
        [HttpPost]
        public ActionResult Create(OrderDetail orderDetail)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.OrderDetails.Add(orderDetail);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(orderDetail);
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminOrderDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // POST: AdminOrderDetail/Edit/5
        [HttpPost]
        public ActionResult Edit(OrderDetail orderDetail)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    db.Entry(orderDetail).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(orderDetail);
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminOrderDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // POST: AdminOrderDetail/Delete/5
        [HttpPost]
        public ActionResult Delete(OrderDetail orderDetail)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    db.OrderDetails.Remove(orderDetail);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(orderDetail);
            }
            catch
            {
                return View();
            }
        }
    }
}
