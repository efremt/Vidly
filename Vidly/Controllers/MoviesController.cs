using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            List<Movie> movies = _context.Movies.Include(m => m.GenreType).ToList();

            return View(movies);
        }

        public ViewResult Details(int id)
        {
            var movies = _context.Movies.Include(g => g.GenreType).SingleOrDefault(c=>c.Id==id);

            return View(movies);
        }

        public ViewResult New()
        {
            List<GenreType> genreTypes= this._context.GenreTypes.ToList();
            MovieFormViewModel ViewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                GenreType= genreTypes
            };

            return this.View("MovieForm", ViewModel);
        }

        public ViewResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            List<GenreType> genreTypes = this._context.GenreTypes.ToList();

            MovieFormViewModel ViewModel = new MovieFormViewModel
            {
                Movie = movie,
                GenreType = genreTypes
            };

            return View("MovieForm", ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                movie.DateAdded = DateTime.Now;
                MovieFormViewModel ViewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    GenreType = this._context.GenreTypes
                };

                
                return View("MovieForm", ViewModel);
            }
            
            if (movie.Id != 0)
            {
                Movie MovieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                MovieInDb.Name = movie.Name;
                MovieInDb.ReleaseDate = movie.ReleaseDate;
                MovieInDb.GenreTypeId = movie.GenreTypeId;
                MovieInDb.NumberInStock = movie.NumberInStock;
            }
            else
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customer = customers
            };

            return View(viewModel);
        }
        //// GET: Movies/Random
        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shirek" };
        //    var customers = new List<Customer>
        //    {
        //        new Customer {Name = "Customer 1"},
        //        new Customer {Name = "Customer 2"}
        //    };

        //    var RandomMovieViewModel = new RandomMovieViewModel()
        //    {
        //        Customer = customers,
        //        Movie = movie
        //    };

        //    #region Passing Data to Views
        //    /*  Passing Data to Views
        //     *
        //     * 1. ViewData["RandomMovieViewModel"] = RandomMovieViewModel;
        //     * 2. ViewBag.Movie = movie;
        //     * 3. return View(RandomMovieViewModel);
        //     *
        //     * Avoid using ViewData and ViewBag because they are fragil. Plus, you have to do extra casting,
        //     * which makes your code ugly. Pass a model(or a view model) directly to a view:
        //     * return View(RandomMovieViewModel);
        //    */
        //    #endregion

        //    return View(RandomMovieViewModel);

        //    #region ActionResult Types
        //    //return Content("Hellow world");
        //    //return PartialView();
        //    //return HttpNotFound();
        //    //return new EmptyResult();
        //    //returm RedirectToAction("intex", "Home", new {page = 1, Sortby = "name"});
        //    # endregion

        //}

        //public ActionResult Edit(int id)
        //{
        //    return Content($"Id: {id}");
        //}

        //#region Regulare Expression description
        ///* Regulare expression description
        // Route is an attribut route that is used to route the request.
        // Regular expression: A regular expression is a pattern that the regular expression engine attempts to match in input text.
        // ex
        //    - In {Year:regex(2018|2017)} regex(2018|2017) is a regular expression inforcing the year should only be 2018 or 2017
        //    - In {Month:regex(\\d{2}):range(1,12)} regex(\\d{2}) and range(1,12) is a regular expression inforcing the month should 
        //      only be a two digite input
        // */ 
        //#endregion
        //[Route("movies/ByRelease/{Year:regex(2018|2017)}/{Month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult ByRelease(int year, byte month)
        //{
        //    return Content($"Release Year Year: {year}/{month}");
        //}
        //public ActionResult displayMovies()
        //{
        //    Movie movie1 = new Movie() { Name = "Shirek" };
        //    Movie movie2 = new Movie() { Name = "A Team" };

        //    List<Movie> listMovie = new List<Movie>()
        //    {
        //        movie1,
        //        movie2
        //    };

        //    return View(listMovie);


        //}

        
    }
}