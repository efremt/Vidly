using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models.ViewModel
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<GenreType> GenreType { get; set; }
        public string Title
        {
            get
            {
                if (Movie != null && Movie.Id != 0)
                    return "Edit Movie";
                return "New Movie";
            }
        }
    }
}