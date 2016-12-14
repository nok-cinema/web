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
        public ActionResult ProcessData(SelectedSeatListViewModel selectedSeatList)
        {
            //return Json(Url.Action("Index", "Movies"));
            if (true)
            {
                return RedirectToAction("Index", "Movies");
            }
            return Json("pending");
        }

        //public ActionResult Payment()
        //{
        //    return;
        //}
    }
}