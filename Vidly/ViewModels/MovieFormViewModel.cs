using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> GenreTypes { get; set; }
        public Movie Movie { get; set; }

    }
}