﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using nok_cinema_web.Models;
using nok_cinema_web.ViewModels;
using nok_cinema_web.BLL;
using System.Web.Security;


namespace nok_cinema_web.Controllers
{
    public class PeopleController : Controller
    {
        MEMBER member = new MEMBER();
        PERSON person = new PERSON();
        MemberUserProfile memberuserProfile = new MemberUserProfile();

        private CinemaEntities db = new CinemaEntities();

        // GET: People
        [Authorize]
        public async Task<ActionResult> Index()
        {
            return View(await db.PERSON.ToListAsync());
        }

        public ActionResult ShowInformation()
        {
            var profile = TempData["UserProfileData"] as EmployeeUserProfile;
            if (profile != null)
            {
                return View("Profile", profile);
            }
            return RedirectToAction("Login", "Authentication");
        }

        // GET: People/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSON pERSON = await db.PERSON.FindAsync(id);
            if (pERSON == null)
            {
                return HttpNotFound();
            }
            return View(pERSON);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD")] PERSON pERSON)
        {
            if (ModelState.IsValid)
            {
                db.PERSON.Add(pERSON);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pERSON);
        }

        // GET: People/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
                return RedirectToAction("Index","Home");
            else
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                DateTime expiration = ticket.Expiration;
                if (expiration < System.DateTime.Now)
                    return RedirectToAction("Index", "Home");
                else
                {
                    string userName = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                    var peopleBLL = new PeopleBLL();
                    person = peopleBLL.GetPersonByCookie(userName);

                    var membersBLL = new MemberBLL();
                    member = membersBLL.GetMerberByCitizenId(person.CITIZENID);
                    if (member.EXPIRYDATE > DateTime.Now)
                    {
                        PERSON pERSON = await db.PERSON.FindAsync(member.CITIZENID);
                        if (pERSON == null)
                        {
                            return HttpNotFound();
                        }
                        return View(pERSON);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //PERSON pERSON = await db.PERSON.FindAsync(id);
            //if (pERSON == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(pERSON);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD")] PERSON pERSON, string newPassword)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pERSON).State = EntityState.Modified;
                pERSON.PASSWORD = newPassword;
                await db.SaveChangesAsync();
                return RedirectToAction("Edit");
            }
            return View(pERSON);
        }

        // GET: People/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSON pERSON = await db.PERSON.FindAsync(id);
            if (pERSON == null)
            {
                return HttpNotFound();
            }
            return View(pERSON);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            PERSON pERSON = await db.PERSON.FindAsync(id);
            db.PERSON.Remove(pERSON);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public JsonResult currentpass(string PASSWORD)
        {
            return Json(!db.PERSON.All(x => x.PASSWORD != PASSWORD), JsonRequestBehavior.AllowGet);
        }
    }
}
