using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using Microsoft.Ajax.Utilities;
using nok_cinema_web.BLL;
using nok_cinema_web.DAL;
using nok_cinema_web.Models;
using nok_cinema_web.ViewModels;

namespace nok_cinema_web.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Theatre(byte theatreId)
        //{
        //    var seatsBLL = new SeatsBLL();
        //    var seatList = new SeatListViewModel();
        //    seatList = seatsBLL.GetSeatListByTheatreId(theatreId);
        //    if (seatList.Seats.Any())
        //    {
        //        return View(seatList);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index");
        //    }
        //}

        public ActionResult Seat(DateTime id1, int id2)
        {
            var seatsBLL = new SeatsBLL();
            var bookingShowtime = seatsBLL.GetBookingShowtimeViewModelByShowtime(id1, id2);

            if (bookingShowtime.Seats.Seats.Any())
            {
                return View(bookingShowtime);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Payment(int movieId, string movieName, string seatRows, string seatNumbers, string dateTime,
            int normalPrice, int sofaPrice, int totalPrice = 0)
        {
            List<string> seatRowData;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            seatRowData = jss.Deserialize<List<string>>(seatRows);
            List<short> seatNumberData;
            seatNumberData = jss.Deserialize<List<short>>(seatNumbers);
            var booking = new BookingTicketViewModel
            {
                Movie = new MOVIE()
                {
                    MOVIEID = movieId,
                    MOVIENAME = movieName
                },
                DateTime = dateTime,
                BookingSeats = new SeatListViewModel(),
                NormalCount = 0,
                SofaCount = 0,
                NormalPrice = normalPrice,
                SofaPrice = sofaPrice
            };
            booking.BookingSeats.Seats = new List<SeatViewModel>();
            for (int i = 0; i < seatNumberData.Count; i++)
            {
                booking.BookingSeats.Seats.Add(new SeatViewModel
                {
                    SeatRow = seatRowData[i],
                    SeatNumber = seatNumberData[i]
                });
                if (seatRowData[i] == "A" || seatRowData[i] == "B" || seatRowData[i] == "C") ++booking.SofaCount;
                else ++booking.NormalCount;
            }
            booking.TotalPrice = totalPrice;
            return View("Payment", booking);
        }

        [HttpPost]
        public ActionResult Ticket(string seatRows, string seatNumbers, string cardId, int movieId, string movieName, string dateTime, int totalPrice = 0)
        {
            List<string> seatRowData;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            seatRowData = jss.Deserialize<List<string>>(seatRows);
            List<short> seatNumberData;
            seatNumberData = jss.Deserialize<List<short>>(seatNumbers);
            var booking = new BookingTicketViewModel
            {
                Movie = new MOVIE()
                {
                    MOVIEID = movieId,
                    MOVIENAME = movieName
                },
                DateTime = dateTime,
                BookingSeats = new SeatListViewModel(),
                NormalCount = 0,
                SofaCount = 0,
            };
            booking.BookingSeats.Seats = new List<SeatViewModel>();
            for (int i = 0; i < seatNumberData.Count; i++)
            {
                booking.BookingSeats.Seats.Add(new SeatViewModel
                {
                    SeatRow = seatRowData[i],
                    SeatNumber = seatNumberData[i]
                });
                if (seatRowData[i] == "A" || seatRowData[i] == "B" || seatRowData[i] == "C") ++booking.SofaCount;
                else ++booking.NormalCount;
            }
            booking.TotalPrice = totalPrice;
            var ticketsBLL = new TicketsBLL();
            int empId, memberId;

            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
            {
                return View();
            }
            else
            {
                string userName = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                var employeeDAL = new EmployeeDAL();
                empId = employeeDAL.GetEmployeeIdByUsername(userName);
                var memberDAL = new MemberDAL();
                memberId = memberDAL.GetMemberIdByUsername(userName);
            }

            ticketsBLL.InsertTickets(booking, empId, memberId);
            return View("Ticket", booking);
        }
    }
}