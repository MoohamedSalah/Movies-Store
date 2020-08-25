using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoviesMoo.Models;
using Microsoft.Office;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI;
using Microsoft.Office.Interop.Word;
using System.Reflection;

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
            ViewBag.DocxContant = "";
            return View();
        }

        private string filePath = "~/Files/";
        public FileResult DownloadFile()
        {
            var sDocument = Server.MapPath(filePath + "Mohamed-Salah-CV.docx");
            byte[] fileBytes = System.IO.File.ReadAllBytes(sDocument);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "Mohamed-Salah-CV.docx");
        }

        // POST: Movies/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movies movies, HttpPostedFileBase Image)
        {
            string GenreSubPath ="";
            switch (movies.Genre)
            {
                case "Action":
                    GenreSubPath = Path.GetFullPath(Server.MapPath("/Files/action.docx"));
                    break;
                case "Drama":
                    GenreSubPath = Path.GetFullPath(Server.MapPath("/Files/Drama.docx"));
                    break;
                case "Comedy":
                    GenreSubPath = Path.GetFullPath(Server.MapPath("/Files/Comedy.docx"));
                    break;
                default:
                    break;

            }

            Application application = new Application();
            Document document = application.Documents.Open(GenreSubPath);

            // Loop through all words in the document.
            int count = document.Words.Count;
            string text = "";
            for (int i = 1; i <= count; i++)
            {
                // Write the word.
                text = text + document.Words[i].Text;

            }
            // Close word.
            application.Quit();
            movies.DocxContant = text;


            if (Image != null)
            {
                movies.MoviesPhoto = new byte[Image.ContentLength];
                Image.InputStream.Read(movies.MoviesPhoto, 0, Image.ContentLength);
            }



            ViewBag.Genre = Genre(null);
            if (db.Movies.Any(x => x.Name == movies.Name))
            {
                ModelState.AddModelError("movies.Name", "Movie name exists");
                return View(movies);
            }

            if (ModelState.IsValid)
            {
                db.spCreateMovie(movies.Id,
                    movies.Name,
                    movies.Genre,
                    movies.ReleasDate,
                    movies.DateAdd,
                    movies.NumberInStock,
                    movies.MemberAvalible,
                    movies.MoviesPhoto,
                    movies.AltPhoto,
                    movies.DocxContant,
                    movies.TrailerUrl);
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
        public ActionResult Edit([Bind(Exclude = "Name")]Movies movies, HttpPostedFileBase Image)
        {
            var movie_id = db.Movies.SingleOrDefault(x => x.Id == movies.Id);
            movies.Name = movie_id.Name;

            if (Image != null)
            {
                movies.MoviesPhoto = new byte[Image.ContentLength];
                Image.InputStream.Read(movies.MoviesPhoto, 0, Image.ContentLength);
            }

            if (movies.MoviesPhoto == null)
                movies.MoviesPhoto = movie_id.MoviesPhoto;

            if (ModelState.IsValid)
            {
                db.spEditeMovies(movies.Id,
                    movies.Name,
                    movies.Genre,
                    movies.ReleasDate,
                    movies.DateAdd,
                    movies.NumberInStock,
                    movies.MemberAvalible,
                    movies.MoviesPhoto,
                    movies.AltPhoto,
                    movies.DocxContant,
                    movies.TrailerUrl);

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
