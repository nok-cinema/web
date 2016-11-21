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
        public List<MovieViewModel> GetMovieListByCategory(string category)
        {
            var db = new CinemaEntities();
            MovieListViewModel movieList = new MovieListViewModel();
            MovieViewModel movie = new MovieViewModel();
            IQueryable<MOVIE> movieQuery = from tmp in db.MOVIE
                                           where tmp.CATEGORY.Equals(category)
                                           select tmp;
            List<MovieViewModel> movies = new List<MovieViewModel>();
            if (movieQuery.Any())
            {
                foreach (var movieTuple in movieQuery)
                {
                    movie.MoveId = movieTuple.MOVIEID;
                    movie.Category = movieTuple.CATEGORY;
                    movie.MovieName = movieTuple.MOVIENAME;
                    movies.Add(movie);
                }
            }
            movieList.Movies = movies;
            movieList.Category = category;
            return movieList.Movies;
        }
    }
}