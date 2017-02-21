using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JCMovies.Models;

namespace JCMovies.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }



        public ActionResult Detail(int? id)
        {
            var detail = GetCustomers().SingleOrDefault(c => c.id == id);

            if (detail == null)
            {
                return HttpNotFound();
            }else
            return View(detail);
        }
        

        //Create a list of using a type of ienumerable (list)
        //creating a list of anonymous type
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                  id  = 1,
                  name = "customer1"
                },

                 new Customer
                {
                  id  = 2,
                  name = "customer2"
                }
            };
        }
    }
}