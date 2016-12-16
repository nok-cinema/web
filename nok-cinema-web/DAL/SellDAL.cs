using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.BLL;
using nok_cinema_web.Models;
using nok_cinema_web.ViewModels;

namespace nok_cinema_web.DAL
{
    public class SellDAL
    {

        public List<SELL> GetSellByDate(DateTime date)
        {
            var db = new CinemaEntities();
            var sells = new List<SELL>();
            var sellQuery = from ticketTmp in db.SELL
                              select ticketTmp;
            foreach (var sellTuple in sellQuery)
            {
                string str = sellTuple.SDATE.ToShortDateString();
                if (str == DateTime.Now.ToShortDateString())
                {
                    var sell = new SELL();
                    sell.FOOD = sellTuple.FOOD;
                    sell.AMOUNT = sellTuple.AMOUNT;
                    sells.Add(sell);
                }
            }
            return sells;
        }

        public List<SELL> GetSellByMonth(DateTime date)
        {
            var db = new CinemaEntities();
            var sells = new List<SELL>();
            var sellQuery = from ticketTmp in db.SELL
                            select ticketTmp;
            foreach (var sellTuple in sellQuery)
            {
                string str = sellTuple.SDATE.ToString("MM");
                if (str == DateTime.Now.ToString("MM"))
                {
                    var sell = new SELL();
                    sell.FOOD = sellTuple.FOOD;
                    sell.FOODID = sellTuple.FOODID;
                    sell.AMOUNT = sellTuple.AMOUNT;
                    sells.Add(sell);
                }
            }
            return sells;
        }
    }
}