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
        public bool Status { get; set; }
            
        public List<MovieViewModel> GetMovieListByCategory(string category)
        {
            var db = new CinemaEntities();
            var movieList = new MovieListViewModel();
            IQueryable<MOVIE> movieQuery = from tmp in db.MOVIE
                                                 where tmp.CATEGORY.Equals(category)
                                                 select tmp;
            
            if (movieQuery.Any())
            {
                foreach (var movieTuple in movieQuery)
                {
                    MovieViewModel movie = new MovieViewModel();
                    movie.MoveId = movieTuple.MOVIEID;
                    movie.Category = movieTuple.CATEGORY;
                    movie.MovieName = movieTuple.MOVIENAME;
                    movieList.Movies.Add(movie);
                }
            }
            movieList.Category = category;
            return movieList.Movies;
        }
    }
}