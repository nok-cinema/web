﻿using System;
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

    public class HomeController : Controller
    {
        CinemaEntities db = new CinemaEntities();
        EMPLOYEE employee = new EMPLOYEE();
        MEMBER member = new MEMBER();
        PERSON person = new PERSON();
        MemberUserProfile memberuserProfile = new MemberUserProfile();
        EmployeeUserProfile employeeuserProfile = new EmployeeUserProfile();

        public ActionResult Index()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
                return View();
            else
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                DateTime expiration = ticket.Expiration;
                if (expiration < System.DateTime.Now)
                    return View();
                else
                {
                    string userName = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                    var peopleBLL = new PeopleBLL();
                    person = peopleBLL.GetPersonByCookie(userName);

                    var memberDAL = new MemberDAL();
                    member = memberDAL.GetMemberByCitizenId(person.CITIZENID);
                    if (member.EXPIRYDATE > DateTime.Now)
                    {
                        memberuserProfile = new MemberUserProfile(member, person);
                        TempData["UserProfileData"] = memberuserProfile;
                        return RedirectToAction("IndexMember");
                    }

                    var employeeDAL = new EmployeeDAL();
                    employee = employeeDAL.GetEmployeeByCitizenId(person.CITIZENID);
                    if (employee.JOBPOSITION != null)
                    {
                        employeeuserProfile = new EmployeeUserProfile(employee, person);
                        TempData["UserProfileData"] = employeeuserProfile;
                        return RedirectToAction("IndexEmployee");
                    }
                    //else
                    //{
                    //    employeeuserProfile = new EmployeeUserProfile(employee, person);
                    //    TempData["UserProfileData"] = employeeuserProfile;
                    //    return RedirectToAction("IndexManager", "Statistics");
                    //}
                    return View();
                }
            }
        }

        [Authorize]
        public ActionResult IndexMember()
        {
            var profile = TempData["UserProfileData"] as MemberUserProfile;
            if (profile != null)
            {
                return View(profile);
            }
            return RedirectToAction("Login", "Authentication");
        }

        [Authorize]
        public ActionResult IndexEmployee()
        {
            var profile = TempData["UserProfileData"] as EmployeeUserProfile;
            if (profile != null)
            {
                return RedirectToAction("SelectMovie", "Movies");
            }
            return RedirectToAction("Login", "Authentication");           
        }
     
    }
}