using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using nok_cinema_web.Models;
using nok_cinema_web.ViewModels;
using nok_cinema_web.BLL;

namespace nok_cinema_web.Controllers
{
    public class AuthenticationController : Controller
    {
        CinemaEntities db = new CinemaEntities();
        EMPLOYEE employee = new EMPLOYEE();
        PERSON person = new PERSON();
        NowLogin nowLogin = new NowLogin();

        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(UserDetails userDetails)
        {
            var personBLL = new PeopleBLL();
            person = personBLL.GetPersonByUserDetails(userDetails);
            
            if (personBLL.Status)
            {
                var employeesBLL = new EmployeesBLL();
                employee = employeesBLL.GetEmployeeByCitizenId(person.CITIZENID);

                nowLogin = new NowLogin(employee, person);
                FormsAuthentication.SetAuthCookie(nowLogin.USERNAME, false);
                TempData["ProfileDetails"] = nowLogin;
                return RedirectToAction("ShowInformation", "People");
            }
            else
            {
                ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                return View("Login");
            }
        }

        [HttpPost]
        public ActionResult Logout()
        {
            nowLogin.Cleanup();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}