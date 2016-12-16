using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using nok_cinema_web.Models;
using nok_cinema_web.ViewModels;
using nok_cinema_web.BLL;
using nok_cinema_web.DAL;

namespace nok_cinema_web.Controllers
{
    public class StatisticsController : Controller
    {
        CinemaEntities db = new CinemaEntities();
        EMPLOYEE employee = new EMPLOYEE();
        MEMBER member = new MEMBER();
        PERSON person = new PERSON();
        MemberUserProfile memberuserProfile = new MemberUserProfile();
        EmployeeUserProfile employeeuserProfile = new EmployeeUserProfile();

        // GET: Statistics
        [Authorize]
        public ActionResult IndexManager()
        {
            string userName = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
            var peopleBLL = new PeopleBLL();
            person = peopleBLL.GetPersonByCookie(userName);
            var employeeDAL = new EmployeeDAL();
            employee = employeeDAL.GetEmployeeByCitizenId(person.CITIZENID);
            if (employee.JOBPOSITION == "Manager")
            {
                employeeuserProfile = new EmployeeUserProfile(employee, person);
                TempData["UserProfileData"] = employeeuserProfile;
                return View("IndexManager", employeeuserProfile);
            }
            return RedirectToAction("Index", "Home");

        }

        public ActionResult StatisticMovie(string option)
        {
            var date = DateTime.Now;
            var ticketBLL = new TicketBLL();
            var ticketlist = new MovieStatisticListViewModel();
            switch (option)
            {
                case "Today":
                    ticketlist = ticketBLL.GetTicketByDate(date);
                    break;
                case "Month":
                    ticketlist = ticketBLL.GetTicketByMonth(date);
                    break;
                default:
                    ticketlist = ticketBLL.GetTicketByCategory(option);
                    break;
            }
            return View(ticketlist);
        }

        [Authorize]
        public ActionResult StatisticFood(string option)
        {
            var date = DateTime.Now;
            var sellBLL = new SellBLL();
            var selllist = new FoodStatisticListViewModel();
            switch (option)
            {
                case "Today":
                    selllist = sellBLL.GetSellByDate(date);
                    break;
                case "Month":
                    selllist = sellBLL.GetSellByMonth(date);
                    break;
                default:
                    break;
            }
            return View(selllist);
        }
    }
}