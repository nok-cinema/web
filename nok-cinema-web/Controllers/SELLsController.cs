using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using nok_cinema_web.Models;

namespace nok_cinema_web.Controllers
{
    public class SELLsController : Controller
    {
        private CinemaEntities db = new CinemaEntities();

        // GET: SELLs
        public async Task<ActionResult> Index()
        {
            var sELL = db.SELL.Include(s => s.EMPLOYEE).Include(s => s.FOOD);
            return View(await sELL.ToListAsync());
        }

        // GET: SELLs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SELL sELL = await db.SELL.FindAsync(id);
            if (sELL == null)
            {
                return HttpNotFound();
            }
            return View(sELL);
        }

        // GET: SELLs/Create
        public ActionResult Create()
        {
            ViewBag.EMPID = new SelectList(db.EMPLOYEE, "EMPID", "JOBPOSITION");
            ViewBag.FOODID = new SelectList(db.FOOD, "FOODID", "NAME");
            return View();
        }

        // POST: SELLs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FOODID,EMPID,SDATE,AMOUNT")] SELL sELL)
        {
            if (ModelState.IsValid)
            {
                db.SELL.Add(sELL);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EMPID = new SelectList(db.EMPLOYEE, "EMPID", "JOBPOSITION", sELL.EMPID);
            ViewBag.FOODID = new SelectList(db.FOOD, "FOODID", "NAME", sELL.FOODID);
            return View(sELL);
        }

        // GET: SELLs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SELL sELL = await db.SELL.FindAsync(id);
            if (sELL == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMPID = new SelectList(db.EMPLOYEE, "EMPID", "JOBPOSITION", sELL.EMPID);
            ViewBag.FOODID = new SelectList(db.FOOD, "FOODID", "NAME", sELL.FOODID);
            return View(sELL);
        }

        // POST: SELLs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FOODID,EMPID,SDATE,AMOUNT")] SELL sELL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sELL).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EMPID = new SelectList(db.EMPLOYEE, "EMPID", "JOBPOSITION", sELL.EMPID);
            ViewBag.FOODID = new SelectList(db.FOOD, "FOODID", "NAME", sELL.FOODID);
            return View(sELL);
        }

        // GET: SELLs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SELL sELL = await db.SELL.FindAsync(id);
            if (sELL == null)
            {
                return HttpNotFound();
            }
            return View(sELL);
        }

        // POST: SELLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SELL sELL = await db.SELL.FindAsync(id);
            db.SELL.Remove(sELL);
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
    }
}
