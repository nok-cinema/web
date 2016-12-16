using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nok_cinema_web.ViewModels
{
    public class FoodStatisticViewModel
    {
        public int Foodid { get; set; }
        public string Foodname { get; set; }
        public long Totalincom { get; set; }
        public long Totalamount { get; set; }

        public FoodStatisticViewModel()
        {
            this.Totalincom = 0;
            this.Totalincom = 0;
        }
    }
}