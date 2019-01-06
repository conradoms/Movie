using Movie.Contexts;
using Movie.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using Movie.ViewModel;
using System;

namespace Movie.Controllers
{
    public class MoviesController : Controller
    {
        public MyContext _context { get; set; }

        public MoviesController()
        {
            _context = new MyContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View(_context.MoviesModel.Include(c => c.Genre).FirstOrDefault(x => x.Id == id));
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieViewModel()
            {
                Genres = genres,
            };

            return View("MovieForm", viewModel);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Save(MovieModel movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.MoviesModel.Add(movie);
            }
            else
            {
                var movieInDb = _context.MoviesModel.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = DateTime.Now;
                movieInDb.GenreId = movie.GenreId;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.MoviesModel.FirstOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieViewModel(movie)
            { 
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }
    }
}