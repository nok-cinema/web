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
        public string[] Price { get; set; }
    }
}