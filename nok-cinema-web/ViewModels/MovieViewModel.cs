using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;

namespace nok_cinema_web.ViewModels
{
    public class MovieViewModel
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public ICollection<CATEGORY> Category { get; set; }
        public DateTime? ShowDate { get; set; }
    }
}