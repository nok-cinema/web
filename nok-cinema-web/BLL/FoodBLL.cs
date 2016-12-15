using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nok_cinema_web.Models;
using nok_cinema_web.ViewModels;
using nok_cinema_web.DAL;

namespace nok_cinema_web.BLL
{
    public class FoodBLL
    {
        public FoodListViewModel GetFoodAll()
        {
            var db = new CinemaEntities();
            var foodDAL = new FoodDAL();
            var foodList = new FoodListViewModel();
            var movieDB = foodDAL.GetFoodAll();

            var foods = new List<FoodViewModel>();
                foreach (var foodTuple in movieDB)
                {
                var food = new FoodViewModel();
                food.FoodID = foodTuple.FOODID;
                food.Name = foodTuple.NAME;
                food.Price = foodTuple.PRICE;
                food.Type = foodTuple.TYPE;
                foods.Add(food);
            }
            foodList.FOODS = foods;
            return foodList;
        }
    }
}