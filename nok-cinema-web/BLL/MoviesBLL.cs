using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;
using nok_cinema_web.ViewModels;
using nok_cinema_web.DAL;

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
                                           where tmp.CATEGORY.Equals(category)
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
            movieList.Category = category;
            return movieList.Movies;
        }

        public List<MovieViewModel> GetMovieListBySearch(string searchstr)
        {
            var movieDAL = new MovieDAL();
            var movieListViewModel = new MovieListViewModel();           

            var movieList = movieDAL.GetMovieBySearch(searchstr);
            var movies = new List<MovieViewModel>();
            foreach(var _movie in movieList)
            {
                var movie = new MovieViewModel();
                movie.MovieId = _movie.MOVIEID;
                movie.MovieName = _movie.MOVIENAME;
                movie.Director = _movie.DIRECTOR;
                movie.Actor = _movie.ACTOR;
                movie.ShortDiscription = _movie.SHORTDESCRIPTION;
                movie.ShowDate = _movie.SHOWDATE;
                movies.Add(movie);
            }
            movieListViewModel.Movies = movies;
            return movieListViewModel.Movies;
        }
    }
}