using JCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using System.Data.Entity;
using JCMovies.Dtos;


namespace JCMovies.Controllers.Api
{
    public class CustomersController : ApiController
    {
        //create dbcontext
        private ApplicationDbContext _context;
        //initialize constructor to use dbcontext
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //dispose



        //GET /api/customers
        //public IEnumerable<Customer> GetCustomers()
        public IHttpActionResult GetCustomers(string query = null)
        {
            //return _context.Customers.ToList();

            //var customersDto = _context.Customers
            //   .Include(c=>c.MembershipType)
            //   .ToList()

            //   .Select((Mapper.Map<Customer,CustomerDto>));



            var customerQuery = _context.Customers
               .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customerQuery = customerQuery.Where(c => c.name.Contains(query));

            var customersDto = customerQuery               
               .ToList()
               .Select((Mapper.Map<Customer, CustomerDto>));


            return Ok(customersDto);
        }

        //Get /api/customers/1
        //public Customer GetCustomer(int id)
       // public CustomerDto  GetCustomer(int id)
       public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            //return customer;
            //return Mapper.Map<Customer, CustomerDto>(customer);
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }


        //POST /api/customers
        [HttpPost]
        // public Customer CreateCustomer(Customer customer)
        // public CustomerDto  CreateCustomer(CustomerDto  customerDto)
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            //check for validations
            if (!ModelState.IsValid)
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            //_context.Customers.Add(customer);
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.id = customer.id;
            //get db context
            //set customer property individualy

            //return customerDto;

            //need to return /api/customers/10
            return Created(new Uri(Request.RequestUri + "/" + customerDto.id), customerDto);
        }


        //put  for update /api/customers/1
        //on updating, we need to supply id and customer detail
        [HttpPut]
        //public void UpdateCustomers(int id, Customer customer)
        public void UpdateCustomers(int id, CustomerDto  customerDto )
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.FirstOrDefault(c => c.id == id);

            //map customer source to target, the fields will be mapped automatically
            Mapper.Map(customerDto, customerInDb);
            //get customer from DB
            

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //customerInDb.name = customer.name;
            //customerInDb.DateOfBirth = customer.DateOfBirth;
            //customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            //customerInDb.MembershipType = customer.MembershipType;
            //customerInDb.MembershipTypeId = customer.MembershipTypeId;
            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteCustomers(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            //get customer from DB
            var updatedCustomer = _context.Customers.FirstOrDefault(c => c.id == id);

            if (updatedCustomer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(updatedCustomer);
            _context.SaveChanges();
        }
    }
}
