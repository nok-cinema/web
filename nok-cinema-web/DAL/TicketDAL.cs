using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.BLL;
using nok_cinema_web.Models;
using nok_cinema_web.ViewModels;

namespace nok_cinema_web.DAL
{
    public class TicketDAL
    {
        public bool InsertTicket(SHOWTIME showtime, SeatViewModel seatViewModel, int empId, int memberId)
        {
            var employeeDAL = new EmployeeDAL();
            var employee = employeeDAL.GetEmployeeByEmployeeId(empId);
            var memberDAL = new MemberDAL();
            var member = memberDAL.GetMemberByMemberId(memberId);
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
            db.SaveChanges();
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
    }
}