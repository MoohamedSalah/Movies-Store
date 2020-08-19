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
    public class CustomersController : ApiController
    {
        private MoviesDBconnectionstring db = new MoviesDBconnectionstring();

        // GET /api/customers

        public IHttpActionResult GetCustomers(string query = null)
        {
            //var customersQuery = db.Customers
            //    .Include(c => c.MemberShipType);

            //if (!String.IsNullOrWhiteSpace(query))
            //    customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            //var customerDtos = customersQuery
            //    .ToList().Select(x=>x.Name.ToList());
            var customersQuery = db.Customers.ToList().Select(x => x.Name).ToList();

            return Ok(customersQuery);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }


    }
}