using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoviesMoo.Models;
using MoviesMoo.ViewModel;


namespace MoviesMoo.Controllers
{
    public class CustomersController : Controller
    {
        private MoviesDBconnectionstring db = new MoviesDBconnectionstring();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.MemberShipType);
            return View(customers.ToList());
        }



        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {

            var memberShipTypes = db.MemberShipType.ToList();
            var viewModel = new VMCustomerMemberType
            {

                MemberShipType = memberShipTypes
            };

            return View(viewModel);
        }

        // POST: Customers/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Customers customers)
        {
            var memberShipTypes = db.MemberShipType.ToList();
            var viewModel = new VMCustomerMemberType
            {
                MemberShipType = memberShipTypes
            };
            if (db.Customers.Any(x => x.Name == customers.Name))
            {
                ModelState.AddModelError("Customers.Name", "Username exists");
                return View(viewModel);
            }
            if (ModelState.IsValid)
            {
                db.Customers.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(viewModel);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            ViewBag.MembershipID = new SelectList(db.MemberShipType, "Id", "Name", customers.MembershipID);
            return View(customers);
        }

        // POST: Customers/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "Name")]Customers customers)
        {
            customers.Name = db.Customers.SingleOrDefault(x => x.Id == customers.Id).Name;

            if (ModelState.IsValid)
            {
                db.spSaveCustomer
                    (customers.Id,
                    customers.Name,
                    customers.IsSubscribedToNewsLetter,
                    customers.MembershipID,
                    customers.Birthdate);
               
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MembershipID = new SelectList(db.MemberShipType, "Id", "Name", customers.MembershipID);
           
            return View(customers);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customers customers = db.Customers.Find(id);
            db.Customers.Remove(customers);
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
