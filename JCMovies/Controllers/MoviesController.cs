using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JCMovies.Models;
using JCMovies.ViewModels;
using Microsoft.Ajax.Utilities;

namespace JCMovies.Controllers
{
    public class MoviesController : Controller
    {
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