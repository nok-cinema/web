using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;

namespace nok_cinema_web.DAL
{
    public class MovieDAL
    {

        public List<REVIEW> GetReviewsByMovieId(int movieId)
        {
            var reviewList = new List<REVIEW>();
            var db = new CinemaEntities();
            IQueryable<REVIEW> reviewQuery = (from reviewTmp in db.REVIEW
                                              where reviewTmp.MOVIEID.Equals(movieId)
                                            select reviewTmp);
            var memberDAL = new MemberDAL();
            if (reviewQuery.Any())
            {
                foreach (var reviewTuple in reviewQuery)
                {
                    var review = new REVIEW
                    {
                        MOVIEID = movieId,
                        COMMENTS = reviewTuple.COMMENTS,
                        MEMBERID = reviewTuple.MEMBERID,
                        RATING = reviewTuple.RATING,
                    };
                    IQueryable<MEMBER> personQuery = (from memberTmp in db.MEMBER
                                                      where memberTmp.MEMBERID.Equals(reviewTuple.MOVIEID)
                                                      select memberTmp);
                    if (personQuery.Any())
                    {
                        foreach (var personTuple in personQuery)
                        {
                            var member = memberDAL.GetMemberByMemberId(review.MEMBERID);
                            review.MEMBER = new MEMBER
                            {
                                PERSON = new PERSON
                                {
                                    USERNAME = member.PERSON.USERNAME
                                }
                            };
                        }
                    }
                    reviewList.Add(review);
                }
            }
            return reviewList;
        }

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

        public List<MOVIE> GetMovieBySearch(string searchstr)
        {
            var db = new CinemaEntities();
            var movieList = new List<MOVIE>();
            var movies = from m in db.MOVIE
                         select m;
            //var actors = from a in db.ACTOR
            //             select a;
            //var categorys = from c in db.CATEGORY
            //                select c;
            if (!String.IsNullOrEmpty(searchstr))
            {
                movies = movies.Where(s => s.MOVIENAME.Contains(searchstr));

                foreach (var _movie in movies)
                {
                    var movie = new MOVIE();
                    movie.MOVIENAME = _movie.MOVIENAME;
                    movie.MOVIEID = _movie.MOVIEID;
                    //movie.SHORTDESCRIPTION = _movie.SHORTDESCRIPTION;
                    //movie.DIRECTOR = _movie.DIRECTOR;                    
                    //movie.SHOWDATE = _movie.SHOWDATE;

                    //actors = actors.Where(s => s.MOVIE.Equals(movie.MOVIEID));
                    //foreach (var _actor in actors)
                    //{
                    //    var actor = new ACTOR();
                    //    actor.ACTORNAME = _actor.ACTORNAME;
                    //    movie.ACTOR.Add(actor);
                    //}
                    //categorys = categorys.Where(s => s.MOVIE.Equals(movie.MOVIEID));
                    //foreach (var _actor in actors)
                    //{
                    //    var category = new CATEGORY();
                    //    category.CATEGORYNAME = category.CATEGORYNAME;
                    //    movie.CATEGORY.Add(category);
                    //}
                    movieList.Add(movie);
                }
            }
            return movieList;
        }

        public MOVIE GetMovieByMovieID(int id)
        {
            var db = new CinemaEntities();
            var movie = new MOVIE();
            var movieQuery = from movieTmp in db.MOVIE
                             where movieTmp.MOVIEID.Equals(id)
                             select movieTmp;
            foreach (var movieTuple in movieQuery)
            {
                movie.MOVIEID = movieTuple.MOVIEID;
                movie.MOVIENAME = movieTuple.MOVIENAME;
                movie.SHORTDESCRIPTION = movieTuple.SHORTDESCRIPTION;
                movie.DIRECTOR = movieTuple.DIRECTOR;
                movie.SHOWDATE = movieTuple.SHOWDATE;
                movie.DURATION = movieTuple.DURATION;
                movie.ACTOR = movieTuple.ACTOR;
                movie.CATEGORY = movieTuple.CATEGORY;
            }         
            return movie;
        }
    }
}