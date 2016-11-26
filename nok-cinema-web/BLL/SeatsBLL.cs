using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.Expressions;
using nok_cinema_web.Models;
using nok_cinema_web.ViewModels;

namespace nok_cinema_web.BLL
{
    public class SeatsBLL
    {
        public SeatListViewModel GetSeatListByTheatreId(byte theatreId)
        {
            var db = new CinemaEntities();
            var seatList = new SeatListViewModel();
            IQueryable<SEAT> seatsQuery = (from tmp in db.SEAT
                                           where tmp.THEATREID.Equals(theatreId)
                                           select tmp).OrderByDescending(s => s.SEATROW).ThenBy(s => s.SEATNUMBER);
            seatList.Seats = new List<SeatViewModel>();
            if (seatsQuery.Any())
            {
                foreach (var seatTuple in seatsQuery)
                {
                    var seat = new SeatViewModel
                    {
                        SeatNumber = seatTuple.SEATNUMBER,
                        SeatRow = seatTuple.SEATROW
                    };
                    if (seatTuple.SEATROW == "A" ||
                        seatTuple.SEATROW == "B" ||
                        seatTuple.SEATROW == "C")
                    {
                        seat.SeatUrl = "~/Content/Images/seat-purple.png";
                    }
                    else
                    {
                        seat.SeatUrl = "~/Content/Images/seat-red.png";
                    }
                    seatList.Seats.Add(seat);
                }
            }
            seatList.TheatreId = theatreId;
            return seatList;
        }
    }
}