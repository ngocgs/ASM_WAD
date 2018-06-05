using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CakeMaker_v4.Controllers
{
    public class AdminOrderController : Controller
    {
        CakeMakerContext db = new CakeMakerContext();
        // GET: AdminOrder
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        // GET: AdminOrder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }

        // GET: AdminOrder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminOrder/Create
        [HttpPost]
        public ActionResult Create(Order order)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(order);
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminOrder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: AdminOrder/Edit/5
        [HttpPost]
        public ActionResult Edit(Order order)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    db.Entry(order).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(order);
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminOrder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: AdminOrder/Delete/5
        [HttpPost]
        public ActionResult Delete(Order order)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    db.Orders.Remove(order);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(order);
            }
            catch
            {
                return View();
            }
        }
    }
}
