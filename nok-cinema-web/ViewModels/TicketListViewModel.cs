using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;

namespace nok_cinema_web.ViewModels
{
    public class TicketListViewModel
    {
        public List<TicketViewModel> Tickets { get; set; }
        public string MovieName { get; set; }
        public DateTime DateTime { get; set; }
        public short TheatreId { get; set; }
    }
}