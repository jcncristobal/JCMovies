using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JCMovies.Models;
using System.Data.Entity;
using JCMovies.ViewModels;
using Microsoft.Owin.Security.Provider;

namespace JCMovies.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            //var customers = GetCustomers();
            //var customers = _context.Customers.ToList();

            //to include membership type as part of customers; need to add reference to entity
           // var customers = _context.Customers.Include(c => c.MembershipType).ToList();
           // return View(customers);
            return View();
        }

        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Detail(int? id)
        {
            //var detail = GetCustomers().SingleOrDefault(c => c.id == id);

            //var detail = _context.Customers.SingleOrDefault(c => c.id == id);

            //Add and include the another db
            var detail = _context.Customers.Include(c=> c.MembershipType).SingleOrDefault(c => c.id == id);

            if (detail == null)
            {
                return HttpNotFound();
            }else
            return View(detail);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            //we need both customer and membershiptype to be displayed
            //so create a ViewModel with a list of membershiptype and customer
            //retrieve the view model 
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer() 
             
            };
            //return View(viewModel);
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            //check modelstate for validations before saving
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }


            if (customer.id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                //TryUpdateModel(customer);

                var updateCustomer = _context.Customers.SingleOrDefault(c => c.id == customer.id);
                //customer properties
                updateCustomer.name = customer.name;
                updateCustomer.DateOfBirth = customer.DateOfBirth;
                updateCustomer.MembershipTypeId = customer.MembershipTypeId;
                updateCustomer.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            }
            _context.SaveChanges();
           // return View();
           return RedirectToAction("Index", "Customer");
        }
        

        //Save a list of using a type of ienumerable (list)
        //creating a list of anonymous type
        private IEnumerable<Customer> GetCustomers(string query = null)
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

        public ActionResult Edit(int id, string name, DateTime? birthdate)
        {
           // throw new NotImplementedException();
            var customer = _context.Customers.SingleOrDefault(c => c.id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            //  var viewModel = new CustomerFormViewModel
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer ,
                MembershipTypes = _context.MembershipTypes.ToList() 
            };
            return View("CustomerForm", viewModel);


        }
    }
}