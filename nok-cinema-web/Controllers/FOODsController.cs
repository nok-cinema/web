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
using nok_cinema_web.BLL;
using nok_cinema_web.DAL;
using nok_cinema_web.ViewModels;
using System.Web.Security;

namespace nok_cinema_web.Controllers
{
    public class FOODsController : Controller
    {
        EMPLOYEE employee = new EMPLOYEE();
        MEMBER member = new MEMBER();
        PERSON person = new PERSON();
        MemberUserProfile memberuserProfile = new MemberUserProfile();
        EmployeeUserProfile employeeuserProfile = new EmployeeUserProfile();
        private CinemaEntities db = new CinemaEntities();

        // GET: FOODs
        public async Task<ActionResult> Index()
        {
            return View(await db.FOOD.ToListAsync());
        }

        // GET: FOODs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOOD fOOD = await db.FOOD.FindAsync(id);
            if (fOOD == null)
            {
                return HttpNotFound();
            }
            return View(fOOD);
        }

        // GET: FOODs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FOODs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FOODID,NAME,TYPE,PRICE")] FOOD fOOD)
        {
            if (ModelState.IsValid)
            {
                db.FOOD.Add(fOOD);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fOOD);
        }

        // GET: FOODs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOOD fOOD = await db.FOOD.FindAsync(id);
            if (fOOD == null)
            {
                return HttpNotFound();
            }
            return View(fOOD);
        }

        // POST: FOODs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FOODID,NAME,TYPE,PRICE")] FOOD fOOD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fOOD).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fOOD);
        }

        // GET: FOODs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOOD fOOD = await db.FOOD.FindAsync(id);
            if (fOOD == null)
            {
                return HttpNotFound();
            }
            return View(fOOD);
        }

        // POST: FOODs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FOOD fOOD = await db.FOOD.FindAsync(id);
            db.FOOD.Remove(fOOD);
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

        public ActionResult Food()
        {
            var foodBLL = new FoodBLL();
            var foodlist = new FoodListViewModel();
            foodlist = foodBLL.GetFoodAll();

            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
                return View(foodlist);
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
                    if (person == null) return RedirectToAction("Index", "Home");

                    var memberDAL = new MemberDAL();
                    member = memberDAL.GetMemberByCitizenId(person.CITIZENID);
                    if (member == null) return RedirectToAction("Index", "Home");
                    if (member.EXPIRYDATE > DateTime.Now)
                    {
                        memberuserProfile = new MemberUserProfile(member, person);
                        TempData["UserProfileData"] = memberuserProfile;
                        return View("FoodMember", foodlist);
                    }

                    var employeeDAL = new EmployeeDAL();
                    employee = employeeDAL.GetEmployeeByCitizenId(person.CITIZENID);
                    if (employee.JOBPOSITION != null)
                    {
                        employeeuserProfile = new EmployeeUserProfile(employee, person);
                        TempData["UserProfileData"] = employeeuserProfile;
                        return View("FoodEmployee", foodlist);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        [HttpPost]
        public ActionResult CalculateFood(string employeeName, int food_1, int food_2, int food_3, int food_4, int food_5, int food_6, int food_7, int food_8)
        {
            List<int> foods = new List<int>();
            foods.Add(0);
            foods.Add(food_1);
            foods.Add(food_2);
            foods.Add(food_3);
            foods.Add(food_4);
            foods.Add(food_5);
            foods.Add(food_6);
            foods.Add(food_7);
            foods.Add(food_8);
            var employeeDAL = new EmployeeDAL();
            var empId = employeeDAL.GetEmployeeIdByUsername(employeeName);
            var foodBLL = new FoodBLL();
            FoodListViewModel foodALL = foodBLL.GetFoodAll();
            var foodDAL = new FoodDAL();
            var foodListViewModel = new FoodListViewModel();
            foodListViewModel.FOODS = new List<FoodViewModel>();
            for (int i = 1; i <= 8; ++i)
            {
                if (foods[i] != 0)
                {
                    if (!foodDAL.InsertFood(i, empId, foods[i]))
                    {
                        foodALL.status = false;
                        return null;
                    }
                    foodALL.status = true;
                    foodALL.FOODS[i-1].Count = foods[i];
                }
            }
            return View("Successful", foodALL);
        }
    }
}
