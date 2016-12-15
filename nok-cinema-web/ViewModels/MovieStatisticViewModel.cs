using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nok_cinema_web.ViewModels
{
    public class MovieStatisticViewModel
    {
        public int Movieid { get; set; }
        public string Moviename { get; set; }
        public long Totalincom { get; set; }
        public long Totalcount { get; set; }

        public MovieStatisticViewModel()
        {
            this.Totalincom = 0;
            this.Totalincom = 0;
        }
    }
}