using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpNotFoundResult();
            }
            var customer = GetCustomers().FirstOrDefault(c => c.Id == id);
            return View(customer);
        }
        public IEnumerable<Customer> GetCustomers()
        {

            return new List<Customer> {
            new Customer {
                Name = "sharon k",
                Id = 1
            },
            new Customer {
                Name = "Joel k",
                Id = 1
            }
            };
        }
    }
}