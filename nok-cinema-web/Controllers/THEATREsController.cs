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
    public class THEATREsController : Controller
    {
        private CinemaEntities db = new CinemaEntities();

        // GET: THEATREs
        public async Task<ActionResult> Index()
        {
            return View(await db.THEATRE.ToListAsync());
        }

        // GET: THEATREs/Details/5
        public async Task<ActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THEATRE tHEATRE = await db.THEATRE.FindAsync(id);
            if (tHEATRE == null)
            {
                return HttpNotFound();
            }
            return View(tHEATRE);
        }

        // GET: THEATREs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: THEATREs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "THEATREID,SEATCAPACITY")] THEATRE tHEATRE)
        {
            if (ModelState.IsValid)
            {
                db.THEATRE.Add(tHEATRE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tHEATRE);
        }

        // GET: THEATREs/Edit/5
        public async Task<ActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THEATRE tHEATRE = await db.THEATRE.FindAsync(id);
            if (tHEATRE == null)
            {
                return HttpNotFound();
            }
            return View(tHEATRE);
        }

        // POST: THEATREs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "THEATREID,SEATCAPACITY")] THEATRE tHEATRE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHEATRE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tHEATRE);
        }

        // GET: THEATREs/Delete/5
        public async Task<ActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THEATRE tHEATRE = await db.THEATRE.FindAsync(id);
            if (tHEATRE == null)
            {
                return HttpNotFound();
            }
            return View(tHEATRE);
        }

        // POST: THEATREs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(byte id)
        {
            THEATRE tHEATRE = await db.THEATRE.FindAsync(id);
            db.THEATRE.Remove(tHEATRE);
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
