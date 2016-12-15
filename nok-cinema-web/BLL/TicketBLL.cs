using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;
using nok_cinema_web.ViewModels;
using nok_cinema_web.DAL;


namespace nok_cinema_web.BLL
{
    public class TicketBLL
    {
        public MovieStatisticListViewModel GetTicketByDate(DateTime date)
        {
            var db = new CinemaEntities();
            var statisticDAL = new TicketDAL();
            var statistic = new MovieStatisticViewModel();
            var statisticList = new MovieStatisticListViewModel();
            var statisticDB = statisticDAL.GetTicketByDate(date);

            int count = 0;
            bool last = false;
            var chk = new List<int>();
            var statistics = new List<MovieStatisticViewModel>();
            foreach (var statisticTuple in statisticDB)
            {
                if (count == statisticDB.Count)
                {
                    last = true;
                }

                var chktmp = chk.FindIndex(x => x.Equals(statisticTuple.MOVIEID));
                if ((chktmp == -1) | (chk.Count() == 0) | last)
                {
                    var movieBLL = new MoviesBLL();
                    var tmp = movieBLL.GetMovieByMovieID(statisticTuple.MOVIEID);
                    statistic.Moviename = tmp.MovieName;
                    if (statisticTuple.SEATROW.Equals("A") | statisticTuple.SEATROW.Equals("B"))
                    {
                        statistic.Totalincom += 200;
                    }
                    else
                    {
                        statistic.Totalincom += 100;
                    }
                    statistic.Totalcount += 1;
                    chk.Add(statisticTuple.MOVIEID);
                    statistics.Add(statistic);
                    statistic = new MovieStatisticViewModel();
                }
                else
                {
                    if (statisticTuple.SEATROW.Equals("A") | statisticTuple.SEATROW.Equals("B"))
                    {
                        statistics[chktmp].Totalincom += 200;
                    }
                    else
                    {
                        statistics[chktmp].Totalincom += 100;
                    }
                    statistics[chktmp].Totalcount += 1;
                }
                count++;
            }
            statisticList.MoviesStatistic = statistics;
            return statisticList;
        }

        public MovieStatisticListViewModel GetTicketByMonth(DateTime date)
        {
            var db = new CinemaEntities();
            var statisticDAL = new TicketDAL();
            var statistic = new MovieStatisticViewModel();
            var statisticList = new MovieStatisticListViewModel();
            var statisticDB = statisticDAL.GetTicketByMonth(date); 

            int count = 0;
            bool last = false;
            var chk = new List<int>();
            var statistics = new List<MovieStatisticViewModel>();
            foreach (var statisticTuple in statisticDB)
            {                
                if (count == statisticDB.Count)
                {
                    last = true;
                }

                var chktmp = chk.FindIndex(x => x.Equals(statisticTuple.MOVIEID));
                if ((chktmp == -1) | (chk.Count() == 0) | last)
                {
                    var movieBLL = new MoviesBLL();
                    var tmp = movieBLL.GetMovieByMovieID(statisticTuple.MOVIEID);
                    statistic.Moviename = tmp.MovieName;
                    if(statisticTuple.SEATROW.Equals("A") | statisticTuple.SEATROW.Equals("B"))
                    {
                        statistic.Totalincom += 200;
                    }
                    else
                    {
                        statistic.Totalincom += 100;
                    }
                    statistic.Totalcount += 1;
                    chk.Add(statisticTuple.MOVIEID);
                    statistics.Add(statistic);
                    statistic = new MovieStatisticViewModel();
                }
                else
                {
                    if (statisticTuple.SEATROW.Equals("A") | statisticTuple.SEATROW.Equals("B"))
                    {
                        statistics[chktmp].Totalincom += 200;
                    }
                    else
                    {
                        statistics[chktmp].Totalincom += 100;
                    }
                    statistics[chktmp].Totalcount += 1;
                }                
                count++;
            }
            statisticList.MoviesStatistic = statistics;
            return statisticList;
        }
    }
}