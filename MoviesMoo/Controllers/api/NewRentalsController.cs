using MoviesMoo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoviesMoo.Controllers.api
{
    public class NewRentalsController : ApiController
    {
        private MoviesDBconnectionstring db = new MoviesDBconnectionstring();

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentals newRental)
        {
            var customer = db.Customers.Single(
                x => x.Id == newRental.Custmerid);

            var movies = db.Movies.Where(
                x => newRental.Movieids.Contains(x.Id));

            foreach (var movie in movies)
            {
                if (movie.MemberAvalible == 0)
                    return BadRequest("One or more Movies are invalid. ");

                movie.MemberAvalible--;
                var rental = new Rentals
                {
                    Customers = customer,
                    Movies = movie,
                    DateRented = DateTime.Now
                };

                db.Rentals.Add(rental);
            }

            db.SaveChanges();
            return Ok();
        }
    }
}
