using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nok_cinema_web.ViewModels;
using nok_cinema_web.BLL;
using System.Globalization;

namespace nok_cinema_web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchstr)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            searchstr = textInfo.ToTitleCase(searchstr);

            var movieBLL = new MoviesBLL();
            var movieListViewModel = new MovieListViewModel();
            movieListViewModel.Movies = movieBLL.GetMovieListBySearch(searchstr);
            return View(movieListViewModel);
        }
    }
}