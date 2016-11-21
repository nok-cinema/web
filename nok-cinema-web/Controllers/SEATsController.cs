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
    public class SEATsController : Controller
    {
        private CinemaEntities db = new CinemaEntities();

        // GET: SEATs
        public async Task<ActionResult> Index()
        {
            var sEAT = db.SEAT.Include(s => s.THEATRE);
            return View(await sEAT.ToListAsync());
        }

        // GET: SEATs/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEAT sEAT = await db.SEAT.FindAsync(id);
            if (sEAT == null)
            {
                return HttpNotFound();
            }
            return View(sEAT);
        }

        // GET: SEATs/Create
        public ActionResult Create()
        {
            ViewBag.THEATREID = new SelectList(db.THEATRE, "THEATREID", "THEATREID");
            return View();
        }

        // POST: SEATs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SEATROW,SEATNUMBER,ZONE,THEATREID")] SEAT sEAT)
        {
            if (ModelState.IsValid)
            {
                db.SEAT.Add(sEAT);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.THEATREID = new SelectList(db.THEATRE, "THEATREID", "THEATREID", sEAT.THEATREID);
            return View(sEAT);
        }

        // GET: SEATs/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEAT sEAT = await db.SEAT.FindAsync(id);
            if (sEAT == null)
            {
                return HttpNotFound();
            }
            ViewBag.THEATREID = new SelectList(db.THEATRE, "THEATREID", "THEATREID", sEAT.THEATREID);
            return View(sEAT);
        }

        // POST: SEATs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SEATROW,SEATNUMBER,ZONE,THEATREID")] SEAT sEAT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sEAT).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.THEATREID = new SelectList(db.THEATRE, "THEATREID", "THEATREID", sEAT.THEATREID);
            return View(sEAT);
        }

        // GET: SEATs/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEAT sEAT = await db.SEAT.FindAsync(id);
            if (sEAT == null)
            {
                return HttpNotFound();
            }
            return View(sEAT);
        }

        // POST: SEATs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            SEAT sEAT = await db.SEAT.FindAsync(id);
            db.SEAT.Remove(sEAT);
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
