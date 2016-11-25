﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;
using nok_cinema_web.ViewModels;

namespace nok_cinema_web.BLL
{
    public class ShowtimeBLL
    {
        public ShowtimeListViewModel GetMovieListByMovieid(int id)
        {
            string name = null;
            var db = new CinemaEntities();
            var showtimeList = new ShowtimeListViewModel();
            var showtime = new ShowtimeViewModel();
            IQueryable<SHOWTIME> showtimeQuery = from tmp in db.SHOWTIME
                                                 where tmp.MOVIEID.Equals(id)
                                                 select tmp;
            List<ShowtimeViewModel> showtimes = new List<ShowtimeViewModel>();
            if (showtimeQuery.Any())
            {
                int i = 1;
                DateTime chk = new DateTime();
                bool first = true;
                bool same;
                foreach (var showtimeTuple in showtimeQuery)
                {
                    if (first)
                    {
                        chk = showtimeTuple.SHOWDATE;
                        name = showtimeTuple.MOVIE.MOVIENAME;
                    }

                    if (chk.ToShortDateString().Equals(showtimeTuple.SHOWDATE.ToShortDateString()))
                    {
                        same = true;
                    }
                    else
                    {
                        same = false;
                    }

                    if (same)
                    {
                        showtime.SHOWDATES.Add(showtimeTuple.SHOWDATE);
                        showtime.DATES = showtimeTuple.SHOWDATE.ToShortDateString();
                        showtime.TIMES.Add(showtimeTuple.SHOWDATE.ToShortTimeString());
                        showtime.MOVIEID = showtimeTuple.MOVIEID;
                        showtime.THEATREID = showtimeTuple.THEATREID;
                    }
                    else
                    {
                        showtimes.Add(showtime);

                        showtime = new ShowtimeViewModel();
                        showtime.SHOWDATES.Add(showtimeTuple.SHOWDATE);
                        showtime.DATES = showtimeTuple.SHOWDATE.ToShortDateString();
                        showtime.TIMES.Add(showtimeTuple.SHOWDATE.ToShortTimeString());
                        showtime.MOVIEID = showtimeTuple.MOVIEID;
                        showtime.THEATREID = showtimeTuple.THEATREID;
                    }

                    if (i == showtimeQuery.Count())
                    {
                        showtime.DATES = showtimeTuple.SHOWDATE.ToShortDateString();
                        showtimes.Add(showtime);
                    }

                    chk = showtimeTuple.SHOWDATE;
                    i++;
                    first = false;
                }
            }
            showtimeList.SHOWTIMES = showtimes;
            showtimeList.MOVIENAME = name;
            return showtimeList;
        }
    }
}