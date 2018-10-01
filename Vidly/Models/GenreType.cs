using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class GenreType
    {
        [Required]
        public byte Id { get; set; }
        [Required]
        public String Genre { get; set; }
    }
}