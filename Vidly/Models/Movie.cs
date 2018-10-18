using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Display (Name="Number In Stock")]
        [Range(1,20,ErrorMessage = "The field Number in Stock must be between 1 and 20")]
        public int NumberInStock { get; set; }

        public GenreType GenreType { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreTypeId { get; set; }

    }
}