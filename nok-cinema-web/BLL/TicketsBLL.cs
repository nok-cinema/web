using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using nok_cinema_web.DAL;
using nok_cinema_web.Models;
using nok_cinema_web.ViewModels;

namespace nok_cinema_web.BLL
{
    public class TicketsBLL
    {
        public TicketListViewModel InsertTickets(BookingTicketViewModel booking, int empId, int memberId)
        {
            var showtime = new SHOWTIME()
            {
                MOVIEID = booking.Movie.MOVIEID,
                SHOWDATE = Convert.ToDateTime(booking.DateTime)
            };
            var theatreDAL = new TheatreDAL();
            theatreDAL.GetTheatreIdByShowtime(showtime);
            var ticketDAL = new TicketDAL();
            foreach (var seatViewModel in booking.BookingSeats.Seats)
            {
                ticketDAL.InsertTicket(showtime, seatViewModel, empId, memberId);
            }
            return ;
        }
    }
}