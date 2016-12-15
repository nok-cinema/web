using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using nok_cinema_web.Controllers;
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
            var ticketDAL = new TicketDAL();
            var ticketListViewModel = new TicketListViewModel();
            ticketListViewModel.Tickets = new List<TicketViewModel>();
            foreach (var seatViewModel in booking.BookingSeats.Seats)
            {
                if (!ticketDAL.InsertTicket(showtime, seatViewModel, empId, memberId))
                {
                    return null;
                }
                ticketListViewModel.DateTime = showtime.SHOWDATE;
                ticketListViewModel.MovieName = booking.Movie.MOVIENAME;
                ticketListViewModel.TheatreId = theatreDAL.GetTheatreIdByShowtime(showtime);
                ticketListViewModel.Tickets.Add(new TicketViewModel
                {
                    Seatnumber = seatViewModel.SeatNumber,
                    Seatrow = seatViewModel.SeatRow
                });
            }
            return ticketListViewModel;
        }

        public HistoryBookedShowtimeMovieIdViewModel GetTicketsFromBooked(int memberId, string memberName)
        {
            var ticketDAL = new TicketDAL();
            var movieShowtimeListViewModel = ticketDAL.GetTicketsFromTheseDays(memberId);
            var history = new HistoryBookedShowtimeMovieIdViewModel
            {
                MovieShowtimeViewModels = movieShowtimeListViewModel,
                MemberName = memberName
            };
            return history;
        }

        public TicketListViewModel GetTicketsFromShowtimeMovieId(DateTime dateTime, int movieId, string userName)
        {
            var ticketDAL = new TicketDAL();
            var memberDAL = new MemberDAL();
            int memberId = memberDAL.GetMemberIdByUsername(userName);
            var ticketListViewModel = ticketDAL.GetTicketsByDatetimeMovieId(dateTime, movieId, memberId);
            return ticketListViewModel;
        }
    }
}