using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;


namespace nok_cinema_web.DAL
{
    public class TicketDAL
    {
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