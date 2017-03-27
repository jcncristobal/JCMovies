using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JCMovies.Models;
using AutoMapper;
using JCMovies.Dtos;

namespace JCMovies.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        //Return DTos
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesDtotest = _context.Movies
                .ToList();


            var moviesQuery = _context.Movies
                .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.name.Contains(query));

            //return _context.Movies.ToList().Select((Mapper.Map<Movie, MovieDto>));


            var moviesDtoTest2 = moviesQuery
               .ToList();

            var moviesDto = moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(moviesDto);
        }

        public IHttpActionResult GetMovie(int Id)
        {
            //get movie from DB using id parameter and return model > modeldto > actionresult
            var movie = _context.Movies.SingleOrDefault(c => c.ID == Id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
            
        }
        
        //POST /api/customers
        [HttpPost]
        // public Customer CreateCustomer(Customer customer)
        // public CustomerDto  CreateCustomer(CustomerDto  customerDto)
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            //check for validations
            if (!ModelState.IsValid)
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            //_context.Customers.Add(customer);
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.ID = movie.ID;
            //get db context
            //set customer property individualy

            //return customerDto;

            //need to return /api/customers/10
            return Created(new Uri(Request.RequestUri + "/" + movieDto.ID), movieDto );
        }


        //put  for update /api/customers/1
        //on updating, we need to supply id and customer detail
        [HttpPut]
        //public void UpdateCustomers(int id, Customer customer)
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Customers.FirstOrDefault(c => c.id == id);

            //map customer source to target, the fields will be mapped automatically
            Mapper.Map(movieDto, movieInDb);
            //get customer from DB


            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            
            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteCustomers(int id, MovieDto movieDto)
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
