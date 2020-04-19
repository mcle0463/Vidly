using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModels;

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

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            return View(movie);
            // return RedirectToAction("Index", "Home", new {page=1, sortBy="name"});
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();

            }

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                GenreTypes = _context.GenreTypes.ToList()
            };
            return View("MovieForm", viewModel);
        }
        // movies
        public ActionResult Index()
        {
            // if (!pageIndex.HasValue)
            //     pageIndex = 1;
            // if (sortBy.IsNullOrWhiteSpace())
            //     sortBy = "Name";
            //return Content(String.Format("pageIndex = {0}, sortBy = {1}", pageIndex, sortBy));
            var movies = _context.Movies.Include(c =>c.Genre).ToList();

            return View(movies);
        }
        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);

        }

        public ActionResult Details(int? id)
        {

            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
        public ActionResult New()
        {
            var genreTypes = _context.GenreTypes.ToList();
            var viewModel = new MovieFormViewModel()
            {
                GenreTypes = genreTypes
            };
            return View("MovieForm", viewModel);
        }
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}