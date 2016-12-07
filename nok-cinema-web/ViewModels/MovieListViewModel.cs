using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;

namespace nok_cinema_web.ViewModels
{
    public class MovieListViewModel
    {
        public List<MovieViewModel> Movies { get; set; }
        public CATEGORY Category { get; set; }
    }
}