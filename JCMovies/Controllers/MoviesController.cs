using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JCMovies.Models;
using JCMovies.ViewModels;
using Microsoft.Ajax.Utilities;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace JCMovies.Controllers
{
    public class MoviesController : Controller
    {

        public ActionResult Index()
        {
            //access db context and get the object
            var movies = _dbContext.Movies.ToList();

            return View(movies);
        }

        //create DB context
        private ApplicationDbContext _dbContext;

        //create new db context instance upon instance of Movies

       public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
            
        }

        //on dispose , also dispose the context, override dispose
        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }


        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() {name = "NetGear", type = "Action"};


            //include customer on the view
            //create a customer list 
            var customers = new List<Customer>
            {
                new Customer {id=1, name = "JC"},
                new Customer {id = 2,name = "Kim"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers

            };
           // ViewData["Movie"] = movie; -old
           //ViewBag.Movie = -do not use old approach



            return View(viewModel);
            //return View(movie);
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            // return RedirectToAction("Index","Home", new {page = 1, sortBy = "name"});

        }



        public ActionResult Detail(int? ID)
        {
            var movie = _dbContext.Movies.SingleOrDefault(m => m.ID == ID);
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            //get movie
            var movie = _dbContext.Movies.SingleOrDefault(c => c.ID == id);
            if (id == null)
            {
                return HttpNotFound();
            }


            return View("MovieForm",movie);
        }

        public ActionResult New()
        {
            //var movies = _dbContext.Movies.ToList();
            return View("MovieForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Save(Movie movie)
        {
            //This Action Result will be called upon postback of submit button
            //as specified on the form wrapper


            if (!ModelState.IsValid)
            {
                return View("MovieForm",movie);
            }



            //add the movie item to dbcontext
            if (movie.ID == 0)
            {
                _dbContext.Movies.Add(movie);
            }
            else
            {
                var updatedMovie = _dbContext.Movies.SingleOrDefault(c => c.ID == movie.ID);
                updatedMovie.name = movie.name;
                updatedMovie.genre = movie.genre;
                updatedMovie.type = movie.type;
                updatedMovie.DateAdded = movie.DateAdded;
                updatedMovie.ReleaseDate = movie.ReleaseDate;
                updatedMovie.Stocks = movie.Stocks;
            }

            try
            {
                _dbContext.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {

                throw;
            }            //return View();
            return RedirectToAction("Index");
        }
        
        //public ActionResult Edit(int id)
        //{
        //    return Content("id = " + id);
        //}


        //public ActionResult Index(int? pageIndex, string sortBy)
        //{

        //    if (!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }

        //    if (sortBy.IsNullOrWhiteSpace())
        //    {
        //        sortBy = "Name";
        //    }

        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

        //}


        //create attribute route constraints - not working
        // [Route("movies/released/{year}/{month:regex(\\d{2}):range:(1:2)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {

            //return View();
            return Content(year + "/" + month);
        }
    }
}