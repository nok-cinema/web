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
                        seat.Class = "S";
                    }
                    else
                    {
                        seat.SeatUrl = "~/Content/Images/seat-red.png";
                        seat.Class =  "N";
                    }
                    seatList.Seats.Add(seat);
                }
            }
            seatList.TheatreId = theatreId;
            seatList.SeatArray = GetSeatListForJavascriptArray(seatList);
            return seatList;
        }

        public List<string> GetSeatListForJavascriptArray(SeatListViewModel seatListViewModel)
        {
            var seatArray = new List<string>();
            string seatFormat = string.Empty;
            foreach (var seat in seatListViewModel.Seats)
            {
                seatFormat += seat.Class;
                if (seat.SeatNumber == 10)
                {
                    seatFormat += "_";
                }
                else if (seat.SeatNumber == 20)
                {
                    seatArray.Add(seatFormat);
                    seatFormat = string.Empty;
                }
            }
            return seatArray;
        }
    }
}