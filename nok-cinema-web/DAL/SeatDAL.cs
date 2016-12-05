using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;

namespace nok_cinema_web.DAL
{
    public class SeatDAL
    {
        public List<SEAT> GetSeatByTheatreId(byte theatreId)
        {
            var db = new CinemaEntities();
            IQueryable<SEAT> seatsQuery = (from seatTmp in db.SEAT
                                           where seatTmp.THEATREID.Equals(theatreId)
                                           select seatTmp).OrderByDescending(s => s.SEATROW).ThenBy(s => s.SEATNUMBER);
            var seatList = new List<SEAT>();
            if (seatsQuery.Any())
            {
                foreach (var seatTuple in seatsQuery)
                {
                    var seat = new SEAT()
                    {
                         SEATROW = seatTuple.SEATROW,
                         SEATNUMBER = seatTuple.SEATNUMBER
                    };
                    seatList.Add(seat);
                }
            }
            return seatList;
        }
    }
}