using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;
using nok_cinema_web.ViewModels;

namespace nok_cinema_web.DAL
{
    public class TicketDAL
    {
        public bool InsertTicket(SHOWTIME showtime, SeatViewModel seatViewModel, int empId, int memberId)
        {
            var db = new CinemaEntities();
            var t = new TICKET
            {
                MEMBERID = memberId,
                SEATROW = seatViewModel.SeatRow,
                SEATNUMBER = seatViewModel.SeatNumber,
                THEATREID = showtime.THEATREID,
                SHOWDATE = showtime.SHOWDATE,
                MOVIEID = showtime.MOVIEID,
                EMPID = empId,
                
                
            };
            db.TICKET.Add(t);
            return db.SaveChanges() > 0;
        }
    }
}