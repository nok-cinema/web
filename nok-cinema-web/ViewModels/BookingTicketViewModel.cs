using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using nok_cinema_web.Models;

namespace nok_cinema_web.ViewModels
{
    public class BookingTicketViewModel
    {
        public MOVIE Movie { get; set; }
        public string DateTime { get; set; }
        public SeatListViewModel BookingSeats { get; set; }
    }
}