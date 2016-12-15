using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;

namespace nok_cinema_web.ViewModels
{
    public class TicketViewModel
    {
        public int Ticketid { get; set; }
        public string Seatrow { get; set; }
        public short Seatnumber { get; set; }
    }
}