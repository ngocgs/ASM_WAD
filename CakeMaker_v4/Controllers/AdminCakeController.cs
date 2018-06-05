using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CakeMaker_v4.Controllers
{
    public class AdminCakeController : Controller
    {
        CakeMakerContext db = new CakeMakerContext();
        // GET: AdminCake
        public ActionResult Index()
        {
            return View(db.Cakes.ToList());
        }

        // GET: AdminCake/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cake cake = db.Cakes.Find(id);
            if (cake == null)
            {
                return HttpNotFound();
            }

            return View(cake);
        }

        // GET: AdminCake/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminCake/Create
        [HttpPost]
        public ActionResult Create(Cake cake)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Cakes.Add(cake);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(cake);
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminCake/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cake cake = db.Cakes.Find(id);
            if (cake == null)
            {
                return HttpNotFound();
            }
            return View(cake);
        }

        // POST: AdminCake/Edit/5
        [HttpPost]
        public ActionResult Edit(Cake cake)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    db.Entry(cake).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(cake);
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminCake/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cake cake = db.Cakes.Find(id);
            if (cake == null)
            {
                return HttpNotFound();
            }
            return View(cake);
        }

        // POST: AdminCake/Delete/5
        [HttpPost]
        public ActionResult Delete(Cake cake)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    db.Cakes.Remove(cake);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(cake);
            }
            catch
            {
                return View();
            }
        }
    }
}
