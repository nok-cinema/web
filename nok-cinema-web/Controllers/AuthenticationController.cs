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
        MEMBER member = new MEMBER();
        PERSON person = new PERSON();
        MemberUserProfile memberuserProfile = new MemberUserProfile();
        EmployeeUserProfile employeeuserProfile = new EmployeeUserProfile();

        // GET: Authentication
        public ActionResult Login()
        {
            //if (Request.IsAuthenticated)
            //{
            //    return RedirectToAction("ShowInformation", "People");
            //}
            //return View();
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

                    var membersBLL = new MemberBLL();
                    member = membersBLL.GetMerberByCitizenId(person.CITIZENID);
                    if(member.EXPIRYDATE > DateTime.Now)
                    {
                        memberuserProfile = new MemberUserProfile(member, person);
                        TempData["UserProfileData"] = memberuserProfile;
                        return RedirectToAction("IndexMember", "Home");
                    }

                    var employeesBLL = new EmployeesBLL();
                    employee = employeesBLL.GetEmployeeByCitizenId(person.CITIZENID);
                    if (employee.JOBPOSITION != "Manager")
                    {
                        employeeuserProfile = new EmployeeUserProfile(employee, person);
                        TempData["UserProfileData"] = employeeuserProfile;
                        return RedirectToAction("IndexEmployee", "Home");
                    }
                    else
                    {
                        employeeuserProfile = new EmployeeUserProfile(employee, person);
                        TempData["UserProfileData"] = employeeuserProfile;
                        return RedirectToAction("Index", "Movies");
                    }
                    return View("Login");
                }
            }
        }

        [HttpPost]
        public ActionResult DoLogin(UserDetails userDetails)
        {
            var personBLL = new PeopleBLL();
            person = personBLL.GetPersonByUserDetails(userDetails);
            
            if (personBLL.Status)
            {
                var membersBLL = new MemberBLL();
                member = membersBLL.GetMerberByCitizenId(person.CITIZENID);
                if (member.EXPIRYDATE > DateTime.Now)
                {
                    memberuserProfile = new MemberUserProfile(member, person);
                    FormsAuthentication.SetAuthCookie(memberuserProfile.USERNAME, false);
                    TempData["UserProfileData"] = memberuserProfile;
                    return RedirectToAction("IndexMember", "Home");
                }

                var employeesBLL = new EmployeesBLL();
                employee = employeesBLL.GetEmployeeByCitizenId(person.CITIZENID);
                if (employee.JOBPOSITION != "Manager")
                {
                    employeeuserProfile = new EmployeeUserProfile(employee, person);
                    FormsAuthentication.SetAuthCookie(employeeuserProfile.USERNAME, false);
                    TempData["UserProfileData"] = employeeuserProfile;
                    return RedirectToAction("IndexEmployee", "Home");
                }
                else
                {
                    employeeuserProfile = new EmployeeUserProfile(employee, person);
                    FormsAuthentication.SetAuthCookie(employeeuserProfile.USERNAME, false);
                    TempData["UserProfileData"] = employeeuserProfile;
                    return RedirectToAction("Index", "Movies");
                }
                return View("Login");
            }
            else
            {
                ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                return View("Login");
            }
        }

        public ActionResult Logout()
        {           
            memberuserProfile.Cleanup();
            employeeuserProfile.Cleanup();
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        // GET: Authentication/Register
        public ActionResult Register()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
            {
                return View();
            }
            else
            {
                string userName = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                var peopleBLL = new PeopleBLL();
                person = peopleBLL.GetPersonByCookie(userName);
                var membersBLL = new MemberBLL();
                member = membersBLL.GetMerberByCitizenId(person.CITIZENID);

                memberuserProfile = new MemberUserProfile(member, person);
                TempData["UserProfileData"] = memberuserProfile;
                return RedirectToAction("IndexMember", "Home");
            }
        }

        // POST: Authentication/Register
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DoRegister([Bind(Include = "CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD")] PERSON pERSON)
        {
            if (ModelState.IsValid)
            {
                MEMBER member = new MEMBER();
                member.CITIZENID = pERSON.CITIZENID;
                member.STARTDATE = DateTime.Now;
                member.EXPIRYDATE = DateTime.Now.AddYears(1);
                db.MEMBER.Add(member);
                db.PERSON.Add(pERSON);
                await db.SaveChangesAsync();
                return RedirectToAction("Login");
            }

            //return View(pERSON);
            return RedirectToAction("Register");
        }
    }
}