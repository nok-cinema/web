using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using Microsoft.Ajax.Utilities;
using nok_cinema_web.BLL;
using nok_cinema_web.Controllers;
using nok_cinema_web.Models;
using nok_cinema_web.ViewModels;

namespace nok_cinema_web.DAL
{
    public class TicketDAL
    {
        public bool InsertTicket(SHOWTIME showtime, SeatViewModel seatViewModel, int empId, int memberId)
        {
            if (showtime == null || seatViewModel == null) return false;
            var showtimeDAL = new ShowtimeDAL();
            var showtimeDetail = showtimeDAL.GetShowtimeDetailByDateTimeAndMovieId(showtime.SHOWDATE, showtime.MOVIEID);
            var db = new CinemaEntities();
            var t = new TICKET
            {
                MEMBERID = memberId,
                SEATROW = seatViewModel.SeatRow,
                SEATNUMBER = seatViewModel.SeatNumber,
                THEATREID = showtimeDetail.THEATREID,
                SHOWDATE = showtime.SHOWDATE,
                MOVIEID = showtime.MOVIEID,
                EMPID = empId
            };
            db.TICKET.Add(t);
            if (db.SaveChanges() > 0) return true;
            else return false;
        }

        public List<TICKET> GetTicketByDate(DateTime date)
        {
            var db = new CinemaEntities();
            var tickets = new List<TICKET>();
            var ticketQuery = from ticketTmp in db.TICKET
                              select ticketTmp;
            foreach (var ticketTuple in ticketQuery)
            {
                string str = ticketTuple.SHOWDATE.ToShortDateString();
                if (str == DateTime.Now.ToShortDateString())
                {
                    var ticket = new TICKET();
                    ticket.MOVIEID = ticketTuple.MOVIEID;
                    ticket.SEATROW = ticketTuple.SEATROW;
                    ticket.SHOWDATE = ticketTuple.SHOWDATE;
                    tickets.Add(ticket);
                }
            }
            return tickets;
        }

        public List<TICKET> GetTicketByMonth(DateTime date)
        {
            var db = new CinemaEntities();
            var tickets = new List<TICKET>();
            IQueryable<TICKET> ticketQuery = from ticketTmp in db.TICKET
                                             select ticketTmp;
            foreach (var ticketTuple in ticketQuery)
            {
                string str = ticketTuple.SHOWDATE.ToString("MM");
                if (str == DateTime.Now.ToString("MM"))
                {
                    var ticket = new TICKET();
                    ticket.MOVIEID = ticketTuple.MOVIEID;
                    ticket.SEATROW = ticketTuple.SEATROW;
                    ticket.SHOWDATE = ticketTuple.SHOWDATE;
                    tickets.Add(ticket);
                }
            }
            return tickets;
        }

        public List<MovieShowtimeViewModel> GetTicketsFromTheseDays(int memberId)
        {
            var db = new CinemaEntities();
            var movieShowtimeViewModel = new List<MovieShowtimeViewModel>();
            var ticketQuery = db.TICKET.Where(m => m.MEMBERID.Equals(memberId));
            var ticketQue = ticketQuery.DistinctBy(m => new {m.SHOWTIME.SHOWDATE, m.MOVIEID}).ToList();
            //var ticketQuery = (from ticketTmp in db.TICKET
            //                       //where ticketTmp.SHOWDATE >= minusThreeDateTime.Today.AddDays(-3)
            //                   where ticketTmp.MEMBERID.Equals(memberId)
            //                   select ticketTmp).DistinctBy(s => s.SHOWTIME.SHOWDATE).OrderByDescending(dt => dt.SHOWDATE).ThenByDescending(m => m.MOVIEID);
            if (ticketQue.Any())
            {
                foreach (var ticketTuple in ticketQue)
                {
                    var showtimeViewModel = new MovieShowtimeViewModel
                    {
                        MovieId = ticketTuple.MOVIEID,
                        MovieName = ticketTuple.SHOWTIME.MOVIE.MOVIENAME,
                        Showtime = ticketTuple.SHOWTIME,
                        DateTime = ticketTuple.SHOWDATE.ToString("f")
                };
                    movieShowtimeViewModel.Add(showtimeViewModel);
                }
            }
            return movieShowtimeViewModel;
        }

        public TicketListViewModel GetTicketsByDatetimeMovieId(DateTime dateTime, int movieId, int memberId)
        {
            var db = new CinemaEntities();
            var ticketListViewModel = new TicketListViewModel();
            ticketListViewModel.Tickets = new List<TicketViewModel>();
            var ticketQuery = db.TICKET.Where(e => e.MEMBERID.Equals(memberId)).Where(m => m.MOVIEID.Equals(movieId)).Where(m => m.SHOWTIME.SHOWDATE.Equals(dateTime));
            if (ticketQuery.Any())
            {
                foreach (var ticketTuple in ticketQuery)
                {
                    var showtimeViewModel = new TicketViewModel
                    {
                        Seatrow = ticketTuple.SEATROW,
                        Seatnumber = ticketTuple.SEATNUMBER,
                        Ticketid = ticketTuple.TICKETID,
                    };
                    ticketListViewModel.TheatreId = ticketTuple.THEATREID;
                    ticketListViewModel.MovieName = ticketTuple.SHOWTIME.MOVIE.MOVIENAME;ticketTuple.SHOWDATE.ToString("f");
                    ticketListViewModel.Tickets.Add(showtimeViewModel);
                }
            }
            ticketListViewModel.DateTime = dateTime;
            return ticketListViewModel;
        }
    }
}