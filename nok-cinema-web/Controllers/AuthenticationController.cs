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
        UserProfile userProfile = new UserProfile();

        // GET: Authentication
        public ActionResult Login()
        {
            HttpContext.Current.User.Identity.IsAuthenticated
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

                userProfile = new UserProfile(employee, person);
                FormsAuthentication.SetAuthCookie(userProfile.USERNAME, false);
                TempData["UserProfileData"] = userProfile;
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
            userProfile.Cleanup();
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}