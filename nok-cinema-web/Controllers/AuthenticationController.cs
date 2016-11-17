using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using nok_cinema_web.Models;
using nok_cinema_web.ViewModels;

namespace nok_cinema_web.Controllers
{
    public class AuthenticationController : Controller
    {
        CinemaEntities db = new CinemaEntities();
        EMPLOYEE employee = new EMPLOYEE();
        PERSON person = new PERSON();
        NowLogin nowlogin = new NowLogin();

        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(PERSON p)
        {


            IQueryable<PERSON> query1 = from tmp in db.PERSON
                                        where tmp.USERNAME.Equals(p.USERNAME) & tmp.PASSWORD.Equals(p.PASSWORD)
                                        select tmp;

            foreach (PERSON temp in query1)
            {
                person.CITIZENID = temp.CITIZENID;
            }

            IQueryable<EMPLOYEE> query2 = from tmp in db.EMPLOYEE
                                          where tmp.PERSON.CITIZENID.Equals(person.CITIZENID)
                                          select tmp;
            if (query1.Count() == 1 && query2.Count() == 1)
            {
                foreach (PERSON _p in query1.ToList())
                {
                    person.FNAME = _p.USERNAME;
                    person.LNAME = _p.LNAME;
                    person.CITIZENID = _p.CITIZENID;
                    person.GENDER = _p.GENDER;
                    person.EMAIL = _p.EMAIL;
                    person.USERNAME = _p.USERNAME;
                    person.PASSWORD = _p.PASSWORD;
                }
                foreach (EMPLOYEE _e in query2.ToList())
                {
                    employee.CITIZENID = _e.CITIZENID;
                    employee.SALARY = _e.SALARY;
                    employee.JOBPOSITION = _e.JOBPOSITION;
                }
                nowlogin = new NowLogin(employee, person);
                FormsAuthentication.SetAuthCookie(nowlogin.USERNAME, false);

                return RedirectToAction("Index", "Home", nowlogin);
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
            nowlogin.Cleanup();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}