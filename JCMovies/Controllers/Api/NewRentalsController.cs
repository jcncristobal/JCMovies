using JCMovies.Dtos;
using JCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JCMovies.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalsDto)
        {


            if (newRentalsDto.MovieIds.Count == 0)
                return BadRequest("Movies is not Valid");

            //Single method since for internal use, if external api - use firstordefault and check if null then bad request
            var customer = _context.Customers.SingleOrDefault (c => c.id == newRentalsDto.CustomerID);

            if(customer == null)        
                return BadRequest("Customer is not Valid");
        

        

            var movies = _context.Movies.Where(m => newRentalsDto.MovieIds.Contains(m.ID)).ToList();

            if(movies.Count != newRentalsDto.MovieIds.Count)
                return BadRequest("One or more movieIDs are invalid");



            List<Rental> rentals = new List<Rental>();
            //Rental rental;
            foreach (Movie movie in movies)
            {

                    if (movie.NumberAvailable == 0)
                    return BadRequest("One or more movie is unavailable");
                    
                    //use a better list assignment approach
                    var rental = new Rental
                    {
                        Customer = customer,
                        Movie = movie,
                        DateRented = DateTime.Now
                    };

                    _context.Rentals.Add(rental);

                    //Update Movie number available
                    movie.NumberAvailable = movie.NumberAvailable - 1;
                
            }

            //saving changes after all processing
            _context.SaveChanges();

           //not implemented 
            return Ok();
        }
    }
}
