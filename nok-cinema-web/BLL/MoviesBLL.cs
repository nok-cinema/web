using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;
using nok_cinema_web.ViewModels;

namespace nok_cinema_web.BLL
{
    public class MoviesBLL
    {
        public List<MovieViewModel> GetMovieListByNowShowing()
        {
            var db = new CinemaEntities();
            var movieList = new MovieListViewModel();
            IQueryable<MOVIE> movieQuery = from tmp in db.MOVIE
                                           where tmp.STATUS.Equals(true)
                                           select tmp;
            movieList.Movies = new List<MovieViewModel>();
            if (movieQuery.Any())
            {
                foreach (var movieTuple in movieQuery)
                {
                    var movie = new MovieViewModel
                    {
                        MovieId = movieTuple.MOVIEID,
                        Category = movieTuple.CATEGORY,
                        MovieName = movieTuple.MOVIENAME,
                        ShowDate = movieTuple.SHOWDATE
                    };
                    movieList.Movies.Add(movie);
                }
            }
            movieList.Movies = movieList.Movies;
            return movieList.Movies;
        }

        public List<MovieViewModel> GetMovieListByCategory(string category)
        {
            var db = new CinemaEntities();
            var movieList = new MovieListViewModel();
            //MovieViewModel movie = new MovieViewModel();
            IQueryable<MOVIE> movieQuery = from tmp in db.MOVIE
                                           where tmp.CATEGORY.Any(c => c.CATEGORYNAME == category)
                                           select tmp;
            movieList.Movies = new List<MovieViewModel>();
            if (movieQuery.Any())
            {
                foreach (var movieTuple in movieQuery)
                {
                    var movie = new MovieViewModel
                    {
                        MovieId = movieTuple.MOVIEID,
                        Category = movieTuple.CATEGORY,
                        MovieName = movieTuple.MOVIENAME,
                        ShowDate = movieTuple.SHOWDATE
                    };
                    movieList.Movies.Add(movie);
                }
            }
            movieList.Category = new CATEGORY {CATEGORYNAME = category};
            return movieList.Movies;
        }
    }
}