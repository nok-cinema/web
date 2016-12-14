using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nok_cinema_web.ViewModels
{
    public class SelectedSeatListViewModel
    {
        public string[] SeatRows { get; set; }
        public string[] SeatNumbers { get; set; }
        public int Price { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Showtime { get; set; }
    }
}