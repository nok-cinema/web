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

                int price = 0;
                switch (statisticTuple.SHOWDATE.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                    case DayOfWeek.Tuesday:
                    case DayOfWeek.Thursday:
                    case DayOfWeek.Friday:
                        price = 120;
                        break;
                    case DayOfWeek.Wednesday:
                        price = 100;
                        break;
                    case DayOfWeek.Saturday:
                    case DayOfWeek.Sunday:
                        price = 140;
                        break;
                    default:
                        price = 120;
                        break;
                }

                var chktmp = chk.FindIndex(x => x.Equals(statisticTuple.MOVIEID));
                if ((chktmp == -1) | (chk.Count() == 0) | last)
                {
                    var movieBLL = new MoviesBLL();
                    var tmp = movieBLL.GetMovieByMovieID(statisticTuple.MOVIEID);
                    statistic.Moviename = tmp.MovieName;
                    if (statisticTuple.SEATROW.Equals("A") | statisticTuple.SEATROW.Equals("B"))
                    {
                        price += 30;
                    }
                    statistic.Totalincom += price;
                    statistic.Totalcount += 1;
                    chk.Add(statisticTuple.MOVIEID);
                    statistics.Add(statistic);
                    statistic = new MovieStatisticViewModel();
                }
                else
                {
                    if (statisticTuple.SEATROW.Equals("A") | statisticTuple.SEATROW.Equals("B"))
                    {
                        price += 30;
                    }
                    statistics[chktmp].Totalincom += price;
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

                int price = 0;
                switch (statisticTuple.SHOWDATE.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                    case DayOfWeek.Tuesday:
                    case DayOfWeek.Thursday:
                    case DayOfWeek.Friday:
                        price = 120;
                        break;
                    case DayOfWeek.Wednesday:
                        price = 100;
                        break;
                    case DayOfWeek.Saturday:
                    case DayOfWeek.Sunday:
                        price = 140;
                        break;
                    default:
                        price = 120;
                        break;
                }

                var chktmp = chk.FindIndex(x => x.Equals(statisticTuple.MOVIEID));
                if ((chktmp == -1) | (chk.Count() == 0) | last)
                {
                    var movieBLL = new MoviesBLL();
                    var tmp = movieBLL.GetMovieByMovieID(statisticTuple.MOVIEID);
                    statistic.Moviename = tmp.MovieName;
                    if (statisticTuple.SEATROW.Equals("A") | statisticTuple.SEATROW.Equals("B"))
                    {
                        price += 30;
                    }
                    statistic.Totalincom += price;
                    statistic.Totalcount += 1;
                    chk.Add(statisticTuple.MOVIEID);
                    statistics.Add(statistic);
                    statistic = new MovieStatisticViewModel();
                }
                else
                {
                    if (statisticTuple.SEATROW.Equals("A") | statisticTuple.SEATROW.Equals("B"))
                    {
                        price += 30;
                    }
                    statistics[chktmp].Totalincom += price;
                    statistics[chktmp].Totalcount += 1;
                }
                count++;
            }
            statisticList.MoviesStatistic = statistics;
            return statisticList;
        }

        public MovieStatisticListViewModel GetTicketByCategory(string category)
        {
            var db = new CinemaEntities();
            var statisticDAL = new TicketDAL();
            var statistic = new MovieStatisticViewModel();
            var statisticList = new MovieStatisticListViewModel();
            var statisticDB = statisticDAL.GetTicketByCategory(category);

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

                int price = 0;
                switch (statisticTuple.SHOWDATE.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                    case DayOfWeek.Tuesday:
                    case DayOfWeek.Thursday:
                    case DayOfWeek.Friday:
                        price = 120;
                        break;
                    case DayOfWeek.Wednesday:
                        price = 100;
                        break;
                    case DayOfWeek.Saturday:
                    case DayOfWeek.Sunday:
                        price = 140;
                        break;
                    default:
                        price = 120;
                        break;
                }

                var chktmp = chk.FindIndex(x => x.Equals(statisticTuple.MOVIEID));
                if ((chktmp == -1) | (chk.Count() == 0) | last)
                {
                    var movieBLL = new MoviesBLL();
                    var tmp = movieBLL.GetMovieByMovieID(statisticTuple.MOVIEID);
                    statistic.Moviename = tmp.MovieName;

                    if (statisticTuple.SEATROW.Equals("A") | statisticTuple.SEATROW.Equals("B"))
                    {
                        price += 30;
                    }

                    statistic.Totalincom += price;
                    statistic.Totalcount += 1;
                    chk.Add(statisticTuple.MOVIEID);
                    statistics.Add(statistic);
                    statistic = new MovieStatisticViewModel();
                }
                else
                {
                    if (statisticTuple.SEATROW.Equals("A") | statisticTuple.SEATROW.Equals("B"))
                    {
                        price += 30;
                    }
                    statistics[chktmp].Totalincom+= price;
                    statistics[chktmp].Totalcount += 1;
                }
                count++;
            }
            statisticList.MoviesStatistic = statistics;
            return statisticList;
        }
    }
}