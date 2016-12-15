using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using nok_cinema_web.Models;
using nok_cinema_web.ViewModels;
using nok_cinema_web.BLL;

namespace nok_cinema_web.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        [Authorize]
        public ActionResult Statistic(string option)
        {
            var date = DateTime.Now;
            var ticketBLL = new TicketBLL();
            var ticketlist = new MovieStatisticListViewModel();
            ticketlist = ticketBLL.GetTicketByMonth(date);
            //switch (option)
            //{
            //    case "Today":
            //    case "Month":
            //    case "Categorie":
            //    default:
            //        break;
            //}
            return View(ticketlist);
        }
    }
}