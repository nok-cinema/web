using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;
using nok_cinema_web.ViewModels;
using nok_cinema_web.DAL;

namespace nok_cinema_web.BLL
{
    public class SellBLL
    {
        public FoodStatisticListViewModel GetSellByDate(DateTime date)
        {
            var db = new CinemaEntities();
            var statisticDAL = new SellDAL();
            var statistic = new FoodStatisticViewModel();
            var statisticList = new FoodStatisticListViewModel();
            var statisticDB = statisticDAL.GetSellByDate(date);

            int count = 0;
            bool last = false;
            var chk = new List<int>();
            var statistics = new List<FoodStatisticViewModel>();
            foreach (var statisticTuple in statisticDB)
            {
                if (count == statisticDB.Count)
                {
                    last = true;
                }

                var chktmp = chk.FindIndex(x => x.Equals(statisticTuple.FOODID));
                if ((chktmp == -1) | (chk.Count() == 0) | last)
                {
                    statistic.Foodname = statisticTuple.FOOD.NAME;
                    statistic.Totalincom += (statisticTuple.FOOD.PRICE * statisticTuple.AMOUNT);
                    statistic.Totalamount += 1;
                    chk.Add(statisticTuple.FOODID);
                    statistics.Add(statistic);
                    statistic = new FoodStatisticViewModel();
                }
                else
                {
                    statistics[chktmp].Totalincom += (statisticTuple.FOOD.PRICE * statisticTuple.AMOUNT);
                    statistics[chktmp].Totalamount += 1;
                }
                count++;
            }
            statisticList.FoodsStatistic = statistics;
            return statisticList;
        }

        public FoodStatisticListViewModel GetSellByMonth(DateTime date)
        {
            var db = new CinemaEntities();
            var statisticDAL = new SellDAL();
            var statistic = new FoodStatisticViewModel();
            var statisticList = new FoodStatisticListViewModel();
            var statisticDB = statisticDAL.GetSellByMonth(date);

            int count = 0;
            bool last = false;
            var chk = new List<int>();
            var statistics = new List<FoodStatisticViewModel>();
            foreach (var statisticTuple in statisticDB)
            {
                if (count == statisticDB.Count)
                {
                    last = true;
                }

                var chktmp = chk.FindIndex(x => x.Equals(statisticTuple.FOODID));
                if ((chktmp == -1) | (chk.Count() == 0) | last)
                {
                    statistic.Foodname = statisticTuple.FOOD.NAME;
                    statistic.Totalincom += (statisticTuple.FOOD.PRICE * statisticTuple.AMOUNT);
                    statistic.Totalamount += 1;
                    chk.Add(statisticTuple.FOODID);
                    statistics.Add(statistic);
                    statistic = new FoodStatisticViewModel();
                }
                else
                {
                    statistics[chktmp].Totalincom += (statisticTuple.FOOD.PRICE * statisticTuple.AMOUNT);
                    statistics[chktmp].Totalamount += 1;
                }
                count++;
            }
            statisticList.FoodsStatistic = statistics;
            return statisticList;
        }
    }
}