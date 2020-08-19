using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoviesMoo.Models;

namespace MoviesMoo.Controllers
{
    public class MemberShipTypesController : Controller
    {
        private MoviesDBconnectionstring db = new MoviesDBconnectionstring();

        // GET: MemberShipTypes
        public ActionResult Index()
        {
            return View(db.MemberShipType.ToList());
        }

        // GET: MemberShipTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberShipType memberShipType = db.MemberShipType.Find(id);
            if (memberShipType == null)
            {
                return HttpNotFound();
            }
            return View(memberShipType);
        }

        // GET: MemberShipTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberShipTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,SignUPFree,DurationInMenths,DiscountRate")] MemberShipType memberShipType)
        {
            if (ModelState.IsValid)
            {
                db.MemberShipType.Add(memberShipType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(memberShipType);
        }

        // GET: MemberShipTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberShipType memberShipType = db.MemberShipType.Find(id);
            if (memberShipType == null)
            {
                return HttpNotFound();
            }
            return View(memberShipType);
        }

        // POST: MemberShipTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,SignUPFree,DurationInMenths,DiscountRate")] MemberShipType memberShipType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memberShipType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(memberShipType);
        }

        // GET: MemberShipTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberShipType memberShipType = db.MemberShipType.Find(id);
            if (memberShipType == null)
            {
                return HttpNotFound();
            }
            return View(memberShipType);
        }

        // POST: MemberShipTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MemberShipType memberShipType = db.MemberShipType.Find(id);
            db.MemberShipType.Remove(memberShipType);
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
