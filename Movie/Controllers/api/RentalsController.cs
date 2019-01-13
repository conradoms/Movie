using Movie.Contexts;
using Movie.Dtos;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Movie.Controllers.api
{
    public class RentalsController : ApiController
    {
        public MyContext _context { get; set; }

        public RentalsController()
        {
            _context = new MyContext();
        }

        [HttpPost]
        public IHttpActionResult Create(RentalDto rentalDto)
        {
            var movieInDb = _context.MoviesModel.Where(m => rentalDto.MoviesId.Contains(m.Id)).ToList();
            var customerInDb = _context.Customers.Single(c => c.Id == rentalDto.CustomerId);
            
            foreach (var movie in movieInDb)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("There is no copy of this movie available.");
                }

                var newRental = new Rental
                {
                    Customer = customerInDb,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rental.Add(newRental);

                movie.NumberAvailable--;
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
