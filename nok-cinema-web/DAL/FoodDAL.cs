using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;

namespace nok_cinema_web.DAL
{
    public class FoodDAL
    {
        public List<FOOD> GetFoodAll()
        {
            var db = new CinemaEntities();
            IQueryable<FOOD> FoodQuery = (from FoodTmp in db.FOOD
                                          select FoodTmp);
            var foodlist = new List<FOOD>();
            foreach (var foodTuple in FoodQuery)
            {
                var food = new FOOD();
                food.FOODID = foodTuple.FOODID;
                food.NAME = foodTuple.NAME;
                food.PRICE = foodTuple.PRICE;
                food.TYPE = foodTuple.TYPE;
                foodlist.Add(food);
            }

            return foodlist;
        }

        public bool InsertFood(int foodId, int empId, int amount)
        {
            if (foodId == 0) return false;
            var db = new CinemaEntities();
            var nowDateTime = DateTime.Now;
            var s = new SELL
            {
                EMPID = empId,
                FOODID = foodId,
                AMOUNT = amount,
                SDATE = nowDateTime
            };
            db.SELL.Add(s);
            if (db.SaveChanges() > 0) return true;
            else return false;
        }
    }
}