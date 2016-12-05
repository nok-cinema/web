using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;

namespace nok_cinema_web.DAL
{
    public class ShowtimeDAL
    {
        public int GetMovieIdByShowdate(DateTime showdate)
        {
            var db = new CinemaEntities();
            IQueryable<SHOWTIME> moviesQuery = (from showtimeTmp in db.SHOWTIME
                                               where showtimeTmp.SHOWDATE.Equals(showdate)
                                               select showtimeTmp);
            int movieid = 0;
            if (moviesQuery.Any())
            {
                foreach (var movieTuple in moviesQuery)
                {
                    movieid = movieTuple.MOVIEID;
                }
            }
            return movieid;
        }

        public List<TICKET> GetTicketsByShowtime(SHOWTIME showtime)
        {
            var db = new CinemaEntities();
            IQueryable<TICKET> ticketsQuery = (from tmp in db.TICKET
                                               where tmp.SHOWTIME.Equals(showtime)
                                               select tmp);
            var ticketList = new List<TICKET>();
            if (ticketsQuery.Any())
            {
                foreach (var ticketTuple in ticketsQuery)
                {
                    var ticket = new TICKET()
                    {
                        TICKETID = ticketTuple.TICKETID,
                        MEMBERID = ticketTuple.MEMBERID,
                        SEATROW = ticketTuple.SEATROW,
                        SEATNUMBER = ticketTuple.SEATNUMBER,
                        THEATREID = ticketTuple.THEATREID,
                        SHOWTIME = ticketTuple.SHOWTIME,
                        EMPID = ticketTuple.EMPID
                    };
                    ticketList.Add(ticket);
                }
            }
            return ticketList;
        }

        public List<SEAT> GetUnavailableSeatsByShowtime(DateTime showtime, int movieid)
        {
            var db = new CinemaEntities();
            IQueryable<TICKET> ticketsQuery = (from ticketTmp in db.TICKET
                                               where ticketTmp.SHOWDATE.Equals(showtime) & ticketTmp.MOVIEID.Equals(movieid)
                                               select ticketTmp);
            var seats = new List<SEAT>();
            if (ticketsQuery.Any())
            {
                foreach (var ticketTuple in ticketsQuery)
                {
                    var seat = new SEAT
                    {
                        SEATROW = ticketTuple.SEATROW,
                        SEATNUMBER = ticketTuple.SEATNUMBER
                    };
                    seats.Add(seat);
                }
            }
            return seats;
        }
    }
}