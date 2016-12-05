using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;

namespace nok_cinema_web.ViewModels
{
    public class BookingShowtimeViewModel
    {
        public MOVIE Movie { get; set; }
        public string DateTime { get; set; }
        public SeatListViewModel Seats { get; set; }
        public List<string> SeatArray { get; set; }
        public List<string> UnavailableSeatArray { get; set; }
    }
}