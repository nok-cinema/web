using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nok_cinema_web.ViewModels
{
    public class MovieListViewModel
    {
        public List<MovieViewModel> Movies { get; set; }
        public string Category { get; set; }
    }
}