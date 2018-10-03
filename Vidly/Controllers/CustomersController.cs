using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    using System.Security.AccessControl;
    using Vidly.Models.ViewModel;

    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;


        public CustomersController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }
        
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);

        }

        public ActionResult New()
        {
            List<MembershipType> membershipTypes = this._context.MembershipTypes.ToList();
            NewCustomerViewModel viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };

            return this.View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Customer customer) //Model binding (Customer customer)
        {
            this._context.Customers.Add(customer);
            this._context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }
    }
}
