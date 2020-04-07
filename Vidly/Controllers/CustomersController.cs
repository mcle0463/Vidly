using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c =>c.MembershipType);
            return View(customers);
        }
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpNotFoundResult();
            }
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            return View(customer);
        }
    }
}