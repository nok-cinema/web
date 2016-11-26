using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nok_cinema_web.BLL;
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

        public ActionResult Theatre(byte theatreId)
        {
            var seatsBLL = new SeatsBLL();
            var seatList = new SeatListViewModel();
            seatList = seatsBLL.GetSeatListByTheatreId(theatreId);
            if (seatList.Seats.Any())
            {
                return View(seatList);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}