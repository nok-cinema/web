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
                MEMBER = member,
                EMPLOYEE = employee,
                SHOWTIME = showtime,
                SEAT = new SEAT()
                {
                    SEATROW = seatViewModel.SeatRow,
                    SEATNUMBER = seatViewModel.SeatNumber,
                    THEATREID = showtime.THEATREID,
                    THEATRE = showtime.THEATRE
                }
            };
            db.TICKET.Add(t);
            return db.SaveChanges() > 0;
        }
    }
}