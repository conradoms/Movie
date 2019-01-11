﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        
        public DateTime DateAdded { get; set; }
        
        [Required]
        [Display(Name = "Number in stock")]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }
        
        public byte NumberAvailable { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public Byte GenreId { get; set; }
    }
}