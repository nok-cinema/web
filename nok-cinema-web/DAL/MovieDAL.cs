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
            int movieId = showtimeDAL.GetMovieIdByShowdate(showtime.SHOWDATE);
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

        public List<MOVIE> GetMovieBySearch(string searchstr)
        {
            var db = new CinemaEntities();
            var movieList = new List<MOVIE>();            
            var movies = from m in db.MOVIE
                         select m;

            if (!String.IsNullOrEmpty(searchstr))
            {
                movies = movies.Where(s => s.MOVIENAME.Contains(searchstr));
                foreach(var _movie in movies)
                {
                    var movie = new MOVIE();
                    movie.MOVIENAME = _movie.MOVIENAME;
                    movie.MOVIEID = _movie.MOVIEID;
                    movie.SHORTDESCRIPTION = _movie.SHORTDESCRIPTION;
                    movie.DIRECTOR = _movie.DIRECTOR;
                    movie.ACTOR = _movie.ACTOR;
                    movie.CATEGORY = _movie.CATEGORY;
                    movie.SHOWDATE = _movie.SHOWDATE;
                    movieList.Add(movie);
                }
            }
            return movieList;
        }
    }
}