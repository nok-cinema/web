using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;

namespace nok_cinema_web.DAL
{
    public class MovieDAL
    {
        public MOVIE GetMovieByShowtime(SHOWTIME showtime)
        {
            var db = new CinemaEntities();
            var showtimeDAL = new ShowtimeDAL();
            int movieId = showtime.MOVIEID;
            IQueryable<MOVIE> movieQuery = (from movieTmp in db.MOVIE
                                            where movieTmp.MOVIEID.Equals(movieId)
                                            select movieTmp);
            var movie = new MOVIE();
            if (movieQuery.Count() == 1)
            {
                foreach (var movieTuple in movieQuery)
                {
                    movie.MOVIEID = movieTuple.MOVIEID;
                    movie.MOVIENAME = movieTuple.MOVIENAME;
                }
            }
            return movie;
        }
    }
}