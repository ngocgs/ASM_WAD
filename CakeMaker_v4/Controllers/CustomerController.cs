using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CakeMaker_v4.Controllers
{
    public class CustomerController : Controller
    {
        CakeMakerContext db = new CakeMakerContext();
        Customer cus;
        OrderDetail ods;
        Order orderP;


        // GET: Cake
        public ActionResult Index()
        {
            return View(db.Cakes.ToList());
        }

        // GET: Admin/Details/5
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

            //cakeProduct = new Cake();
            //cakeProduct = cake;

            ods = new OrderDetail();
            ods.cakeID = cake.cakeID;
            ods.cakePrice = cake.cakePrice;
            ods.cakeQuatity = 1;

            db.OrderDetails.Add(ods);
            //db.SaveChanges();

            return View(cake);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    cus = new Customer();
                    cus = customer;

                    db.Customers.Add(customer);
                    //db.SaveChanges();
                    return RedirectToAction("CreateO");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }


    }
}