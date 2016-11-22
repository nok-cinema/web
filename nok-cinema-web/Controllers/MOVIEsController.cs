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
    public class MOVIEsController : Controller
    {
        private CinemaEntities db = new CinemaEntities();

        // GET: MOVIEs
        public async Task<ActionResult> Index()
        {
            return View(await db.MOVIE.ToListAsync());
        }

        // GET: MOVIEs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIE mOVIE = await db.MOVIE.FindAsync(id);
            if (mOVIE == null)
            {
                return HttpNotFound();
            }
            return View(mOVIE);
        }

        // GET: MOVIEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MOVIEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MOVIEID,MOVIENAME,CATEGORY,DIRECTOR,SHORTDESCRIPTION,ACTOR,DURATION,PLAYCOUNT,STATUS")] MOVIE mOVIE)
        {
            if (ModelState.IsValid)
            {
                db.MOVIE.Add(mOVIE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mOVIE);
        }

        // GET: MOVIEs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIE mOVIE = await db.MOVIE.FindAsync(id);
            if (mOVIE == null)
            {
                return HttpNotFound();
            }
            return View(mOVIE);
        }

        // POST: MOVIEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MOVIEID,MOVIENAME,CATEGORY,DIRECTOR,SHORTDESCRIPTION,ACTOR,DURATION,PLAYCOUNT,STATUS")] MOVIE mOVIE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mOVIE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mOVIE);
        }

        // GET: MOVIEs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIE mOVIE = await db.MOVIE.FindAsync(id);
            if (mOVIE == null)
            {
                return HttpNotFound();
            }
            return View(mOVIE);
        }

        // POST: MOVIEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MOVIE mOVIE = await db.MOVIE.FindAsync(id);
            db.MOVIE.Remove(mOVIE);
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
