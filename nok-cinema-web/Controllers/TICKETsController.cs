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
    public class TICKETsController : Controller
    {
        private CinemaEntities db = new CinemaEntities();

        // GET: TICKETs
        public async Task<ActionResult> Index()
        {
            var tICKET = db.TICKET.Include(t => t.EMPLOYEE).Include(t => t.MEMBER).Include(t => t.SEAT).Include(t => t.SHOWTIME);
            return View(await tICKET.ToListAsync());
        }

        // GET: TICKETs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKET tICKET = await db.TICKET.FindAsync(id);
            if (tICKET == null)
            {
                return HttpNotFound();
            }
            return View(tICKET);
        }

        // GET: TICKETs/Create
        public ActionResult Create()
        {
            ViewBag.EMPID = new SelectList(db.EMPLOYEE, "EMPID", "JOBPOSITION");
            ViewBag.MEMBERID = new SelectList(db.MEMBER, "MEMBERID", "CITIZENID");
            ViewBag.SEATROW = new SelectList(db.SEAT, "SEATROW", "ZONE");
            ViewBag.SHOWDATE = new SelectList(db.SHOWTIME, "SHOWDATE", "SHOWDATE");
            return View();
        }

        // POST: TICKETs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TICKETID,MEMBERID,SEATROW,SEATNUMBER,THEATREID,SHOWDATE,MOVIEID,EMPID")] TICKET tICKET)
        {
            if (ModelState.IsValid)
            {
                db.TICKET.Add(tICKET);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EMPID = new SelectList(db.EMPLOYEE, "EMPID", "JOBPOSITION", tICKET.EMPID);
            ViewBag.MEMBERID = new SelectList(db.MEMBER, "MEMBERID", "CITIZENID", tICKET.MEMBERID);
            ViewBag.SEATROW = new SelectList(db.SEAT, "SEATROW", "ZONE", tICKET.SEATROW);
            ViewBag.SHOWDATE = new SelectList(db.SHOWTIME, "SHOWDATE", "SHOWDATE", tICKET.SHOWDATE);
            return View(tICKET);
        }

        // GET: TICKETs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKET tICKET = await db.TICKET.FindAsync(id);
            if (tICKET == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMPID = new SelectList(db.EMPLOYEE, "EMPID", "JOBPOSITION", tICKET.EMPID);
            ViewBag.MEMBERID = new SelectList(db.MEMBER, "MEMBERID", "CITIZENID", tICKET.MEMBERID);
            ViewBag.SEATROW = new SelectList(db.SEAT, "SEATROW", "ZONE", tICKET.SEATROW);
            ViewBag.SHOWDATE = new SelectList(db.SHOWTIME, "SHOWDATE", "SHOWDATE", tICKET.SHOWDATE);
            return View(tICKET);
        }

        // POST: TICKETs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TICKETID,MEMBERID,SEATROW,SEATNUMBER,THEATREID,SHOWDATE,MOVIEID,EMPID")] TICKET tICKET)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tICKET).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EMPID = new SelectList(db.EMPLOYEE, "EMPID", "JOBPOSITION", tICKET.EMPID);
            ViewBag.MEMBERID = new SelectList(db.MEMBER, "MEMBERID", "CITIZENID", tICKET.MEMBERID);
            ViewBag.SEATROW = new SelectList(db.SEAT, "SEATROW", "ZONE", tICKET.SEATROW);
            ViewBag.SHOWDATE = new SelectList(db.SHOWTIME, "SHOWDATE", "SHOWDATE", tICKET.SHOWDATE);
            return View(tICKET);
        }

        // GET: TICKETs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKET tICKET = await db.TICKET.FindAsync(id);
            if (tICKET == null)
            {
                return HttpNotFound();
            }
            return View(tICKET);
        }

        // POST: TICKETs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TICKET tICKET = await db.TICKET.FindAsync(id);
            db.TICKET.Remove(tICKET);
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
