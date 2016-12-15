using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;

namespace nok_cinema_web.ViewModels
{
    public class ShowtimeListViewModel
    {
        public List<ShowtimeViewModel> SHOWTIMES { get; set; }
        public string MOVIENAME { get; set; }
        public ICollection<CATEGORY> Category { get; set; }
        public Nullable<short> Duration { get; set; }
    }
}