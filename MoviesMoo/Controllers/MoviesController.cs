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
    public class MoviesController : Controller
    {
        private MoviesDBconnectionstring db = new MoviesDBconnectionstring();

        // GET: Movies
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        public JsonResult IsUserNameAvailableMov(string Name)
        {
            return Json(!db.Movies.Any(x => x.Name == Name), JsonRequestBehavior.AllowGet);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movies movies = db.Movies.Find(id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies);
        }
        public SelectList Genre(string selected)
        {
            var list = new SelectList(new[]
            {
                 new { ID = "Action", Name = "Action" },
                 new { ID = "Drama", Name = "Drama" },
                 new { ID = "Comedy", Name = "Comedy" },
            },
             "ID", "Name", selected);
            return list;
        }
        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.Genre = Genre(null);
            return View();
        }

        // POST: Movies/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movies movies)
        {
            ViewBag.Genre = Genre(null);
            if (db.Movies.Any(x => x.Name == movies.Name))
            {
                ModelState.AddModelError("movies.Name", "Movie name exists");
                return View(movies);
            }
            if (ModelState.IsValid)
            {
                db.Movies.Add(movies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movies);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movies movies = db.Movies.Find(id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            ViewBag.Genre = Genre(movies.Genre);
            return View(movies);
        }

        // POST: Movies/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "Name")]Movies movies)
        {
            movies.Name = db.Movies.SingleOrDefault(x => x.Id == movies.Id).Name;

            if (ModelState.IsValid)
            {
                db.spEditeMovies(movies.Id,
                    movies.Name,
                    movies.Genre,
                    movies.ReleasDate,
                    movies.DateAdd,
                    movies.NumberInStock,
                    movies.MemberAvalible);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Genre = Genre(movies.Genre);
            return View(movies);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movies movies = db.Movies.Find(id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movies movies = db.Movies.Find(id);
            db.Movies.Remove(movies);
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
