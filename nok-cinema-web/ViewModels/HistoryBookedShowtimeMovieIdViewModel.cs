using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nok_cinema_web.ViewModels
{
    public class HistoryBookedShowtimeMovieIdViewModel
    {
        public string MemberName { get; set; }
        public List<MovieShowtimeViewModel> MovieShowtimeViewModels { get; set; }
    }
}