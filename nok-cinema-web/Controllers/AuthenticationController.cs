﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            //if (Request.IsAuthenticated)
            //{
            //    return RedirectToAction("ShowInformation", "People");
            //}
            //return View();
            if (Request.Cookies[FormsAuthentication.FormsCookieName] == null)
                return View();
            else
            {
                string userName = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                var peopleBLL = new PeopleBLL();
                person = peopleBLL.GetPersonByCookie(userName);
                var employeesBLL = new EmployeesBLL();
                employee = employeesBLL.GetEmployeeByCitizenId(person.CITIZENID);

                userProfile = new UserProfile(employee, person);
                FormsAuthentication.SetAuthCookie(userProfile.USERNAME, false);
                TempData["UserProfileData"] = userProfile;
                return RedirectToAction("ShowInformation", "People");
            }
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

        // GET: Authentication/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Authentication/Register
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register([Bind(Include = "CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD")] PERSON pERSON)
        {
            if (ModelState.IsValid)
            {
                db.PERSON.Add(pERSON);
                await db.SaveChangesAsync();
                return RedirectToAction("Login");
            }

            //return View(pERSON);
            return RedirectToAction("Login");
        }
    }
}