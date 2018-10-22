using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
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
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }

        // GET /api/Customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer,CustomerDto>( customer));
        }

        // POST /api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri +"/" + customer.Id),customerDto);

        }

        // PUT /api/Customers/1
        [HttpPut]
        public void UpdateCustomer( int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());

            Customer customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb==null)
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());

            Mapper.Map(customerDto,customerInDb);
            
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

//Read about AutoMapper documentation for different property feleid 