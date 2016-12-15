using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;

namespace nok_cinema_web.ViewModels
{
    public class MovieShowtimeViewModel
    {
        public SHOWTIME Showtime{ get; set; }
        public int TicketCount { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string DateTime { get; set; }
    }
}