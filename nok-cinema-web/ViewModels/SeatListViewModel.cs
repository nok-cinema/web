using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nok_cinema_web.ViewModels
{
    public class SeatListViewModel
    {
        public List<SeatViewModel> Seats { get; set; }
        public byte TheatreId { get; set; }
        public List<string> SeatArray { get; set; }
        public List<string> UnavailableSeatArray { get; set; }
    }
}