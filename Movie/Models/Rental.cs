using System;
using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{
    public class Rental
    {
        public int id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public MovieModel Movie { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}