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
    public class REVIEWsController : Controller
    {
        private CinemaEntities db = new CinemaEntities();

        // GET: REVIEWs
        public async Task<ActionResult> Index()
        {
            var rEVIEW = db.REVIEW.Include(r => r.MEMBER);
            return View(await rEVIEW.ToListAsync());
        }

        // GET: REVIEWs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REVIEW rEVIEW = await db.REVIEW.FindAsync(id);
            if (rEVIEW == null)
            {
                return HttpNotFound();
            }
            return View(rEVIEW);
        }

        // GET: REVIEWs/Create
        public ActionResult Create()
        {
            ViewBag.MEMBERID = new SelectList(db.MEMBER, "MEMBERID", "CITIZENID");
            return View();
        }

        // POST: REVIEWs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MOVIEID,MEMBERID,RATING,COMMENTS")] REVIEW rEVIEW)
        {
            if (ModelState.IsValid)
            {
                db.REVIEW.Add(rEVIEW);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MEMBERID = new SelectList(db.MEMBER, "MEMBERID", "CITIZENID", rEVIEW.MEMBERID);
            return View(rEVIEW);
        }

        // GET: REVIEWs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REVIEW rEVIEW = await db.REVIEW.FindAsync(id);
            if (rEVIEW == null)
            {
                return HttpNotFound();
            }
            ViewBag.MEMBERID = new SelectList(db.MEMBER, "MEMBERID", "CITIZENID", rEVIEW.MEMBERID);
            return View(rEVIEW);
        }

        // POST: REVIEWs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MOVIEID,MEMBERID,RATING,COMMENTS")] REVIEW rEVIEW)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEVIEW).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MEMBERID = new SelectList(db.MEMBER, "MEMBERID", "CITIZENID", rEVIEW.MEMBERID);
            return View(rEVIEW);
        }

        // GET: REVIEWs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REVIEW rEVIEW = await db.REVIEW.FindAsync(id);
            if (rEVIEW == null)
            {
                return HttpNotFound();
            }
            return View(rEVIEW);
        }

        // POST: REVIEWs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            REVIEW rEVIEW = await db.REVIEW.FindAsync(id);
            db.REVIEW.Remove(rEVIEW);
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
