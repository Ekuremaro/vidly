using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using Action = Antlr.Runtime.Misc.Action;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET
        
        public ActionResult Index()
        {

            var movies = GetMovies();

            return View(movies);    
        
        }
        
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }
        
        public ActionResult Random()
        {

            var movie = new Movie() { Name = "shrek", Id = 1 };
            var customers = new List<Customer>
            {
                new Customer{Id = 1, Name = "customer 1"},
                new Customer{Id = 2, Name = "customer 2"},
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
        
            
            return View(viewModel);

        }

        public ActionResult Edit(int? pageIndex, string sortBy )
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;

            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content($"pageIndex={pageIndex}&sortBy={sortBy}");
        }

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}