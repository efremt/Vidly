using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/Customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        // GET /api/Customers/1
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());

            return customer;
        }

        // POST /api/Customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;

        }

        // PUT /api/Customers/1
        [HttpPut]
        public void UpdateCustomer(Customer customer, int id)
        {
            if (!ModelState.IsValid)
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());

            Customer DBCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(DBCustomer==null)
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());

            DBCustomer.Name = customer.Name;
            DBCustomer.Birthdate = customer.Birthdate;
            DBCustomer.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            DBCustomer.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();
            
        }

        // DELETE /api/Customers/1
        [HttpDelete]
        public void DeleteCustomer( int id)
        {
            Customer DBCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (DBCustomer == null)
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());

            _context.Customers.Remove(DBCustomer);
            _context.SaveChanges();

        }
    }
}
