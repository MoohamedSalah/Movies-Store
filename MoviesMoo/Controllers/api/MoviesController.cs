using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MoviesMoo.Models;

namespace MoviesMoo.Controllers.api
{
    public class MoviesController : ApiController
    {
        private MoviesDBconnectionstring db = new MoviesDBconnectionstring();

        // GET: api/Movies
        [HttpGet]
        public IQueryable<Movies> Movies()
        {
            return db.Movies;
        }

        // GET: api/Movies/5
        [HttpGet]
        [ResponseType(typeof(Movies))]
        public IHttpActionResult Movies(int id)
        {
            Movies movies = db.Movies.Find(id);
            if (movies == null)
            {
                return NotFound();
            }

            return Ok(movies);
        }

        // PUT: api/Movies/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult Movies(int id, Movies movies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movies.Id)
            {
                return BadRequest();
            }

            db.Entry(movies).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoviesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Movies
        [HttpPost]
        [ResponseType(typeof(Movies))]
        public IHttpActionResult Movies(Movies movies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            db.Movies.Add(movies);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = movies.Id }, movies);
        }

        // DELETE: api/Movies/5
        [HttpDelete]
        [ResponseType(typeof(Movies))]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = db.Movies.Find(id);
            if (movie == null)
                return NotFound();

            db.Movies.Remove(movie);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MoviesExists(int id)
        {
            return db.Movies.Count(e => e.Id == id) > 0;
        }
    }
}