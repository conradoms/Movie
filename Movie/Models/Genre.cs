using System;
using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{
    public class Genre
    {
        public Byte Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}