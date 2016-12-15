using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;

namespace nok_cinema_web.DAL
{
    public class TheatreDAL
    {
        public byte GetTheatreIdByShowtime(SHOWTIME showtime)
        {
            var db = new CinemaEntities();
            IQueryable<SHOWTIME> theatreQuery = (from theatreTmp in db.SHOWTIME
                                               where theatreTmp.MOVIEID.Equals(showtime.MOVIEID) & theatreTmp.SHOWDATE.Equals(showtime.SHOWDATE)
                                               select theatreTmp);
            if (theatreQuery.Any())
            {
                foreach (var theatreTuple in theatreQuery)
                {
                    return theatreTuple.THEATREID;
                }
            }
            return 0;
        }
    }
}