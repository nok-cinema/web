﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nok_cinema_web.ViewModels
{
    public class ShowtimeListViewModel
    {
        public List<ShowtimeViewModel> SHOWTIMES { get; set; }
        public string MOVIENAME { get; set; }
    }
}