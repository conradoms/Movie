using AutoMapper;
using Movie.Contexts;
using Movie.Dtos;
using Movie.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Movie.Controllers.api
{
    public class MoviesController : ApiController
    {
        private MyContext _context;

        public MoviesController()
        {
            _context = new MyContext();
        }

        // GET api/movies
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.MoviesModel.Include(m => m.Genre).ToList().Select(Mapper.Map<MovieModel, MovieDto>));
        }

        // GET api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movieInDb = _context.MoviesModel.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<MovieModel, MovieDto>(movieInDb));
        }

        // POST api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, MovieModel>(movieDto);
            movie.DateAdded = DateTime.Now;

            _context.MoviesModel.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieInDb = _context.MoviesModel.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.MoviesModel.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
            {
                return NotFound();
            }

            _context.MoviesModel.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
