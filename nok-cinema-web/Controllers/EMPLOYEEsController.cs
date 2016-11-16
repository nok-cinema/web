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
    public class EMPLOYEEsController : Controller
    {
        private CinemaEntities db = new CinemaEntities();

        // GET: EMPLOYEEs
        public async Task<ActionResult> Index()
        {
            var eMPLOYEE = db.EMPLOYEE.Include(e => e.PERSON);
            return View(await eMPLOYEE.ToListAsync());
        }

        // GET: EMPLOYEEs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEE eMPLOYEE = await db.EMPLOYEE.FindAsync(id);
            if (eMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEE);
        }

        // GET: EMPLOYEEs/Create
        public ActionResult Create()
        {
            ViewBag.CITIZENID = new SelectList(db.PERSON, "CITIZENID", "FNAME");
            return View();
        }

        // POST: EMPLOYEEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EMPID,JOBPOSITION,SALARY,CITIZENID")] EMPLOYEE eMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                db.EMPLOYEE.Add(eMPLOYEE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CITIZENID = new SelectList(db.PERSON, "CITIZENID", "FNAME", eMPLOYEE.CITIZENID);
            return View(eMPLOYEE);
        }

        // GET: EMPLOYEEs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEE eMPLOYEE = await db.EMPLOYEE.FindAsync(id);
            if (eMPLOYEE == null)
            {
                return HttpNotFound();
            }
            ViewBag.CITIZENID = new SelectList(db.PERSON, "CITIZENID", "FNAME", eMPLOYEE.CITIZENID);
            return View(eMPLOYEE);
        }

        // POST: EMPLOYEEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EMPID,JOBPOSITION,SALARY,CITIZENID")] EMPLOYEE eMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLOYEE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CITIZENID = new SelectList(db.PERSON, "CITIZENID", "FNAME", eMPLOYEE.CITIZENID);
            return View(eMPLOYEE);
        }

        // GET: EMPLOYEEs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEE eMPLOYEE = await db.EMPLOYEE.FindAsync(id);
            if (eMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEE);
        }

        // POST: EMPLOYEEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EMPLOYEE eMPLOYEE = await db.EMPLOYEE.FindAsync(id);
            db.EMPLOYEE.Remove(eMPLOYEE);
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
