using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nok_cinema_web.ViewModels
{
    public class ShowtimeViewModel
    {
        public List<DateTime> SHOWDATES { get; set; }
        public List<string> TIMES { get; set; }
        public string DATES { get; set; }
        public int MOVIEID { get; set; }
        public byte THEATREID { get; set; }

        public ShowtimeViewModel(int m_id, DateTime sd, byte t_id)
        {
            this.MOVIEID = m_id;
            this.SHOWDATES = new List<DateTime>();
            this.SHOWDATES.Add(sd);
            this.THEATREID = t_id;
        }
        public ShowtimeViewModel()
        {
            this.SHOWDATES = new List<DateTime>();
            this.TIMES = new List<string>();
        }
    }
}