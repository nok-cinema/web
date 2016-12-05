using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;
using nok_cinema_web.ViewModels;

namespace nok_cinema_web.BLL
{
    public class TheatreBLL
    {
        public byte GetTheatreIdByShowtime(DateTime showtime, int movieid)
        {
            var db = new CinemaEntities();
            IQueryable<SHOWTIME> theatreQuery = (from theatreTmp in db.SHOWTIME
                                                 where theatreTmp.SHOWDATE.Equals(showtime) & theatreTmp.MOVIEID.Equals(movieid)
                                                 select theatreTmp);
            byte theatreId = 0;
            if (theatreQuery.Count() == 1)
            {
                foreach (var theatre in theatreQuery)
                {
                    theatreId = theatre.THEATREID;
                }
            }
            return theatreId;
        }
    }
}