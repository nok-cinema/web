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
    public class MEMBERsController : Controller
    {
        private CinemaEntities db = new CinemaEntities();

        // GET: MEMBERs
        public async Task<ActionResult> Index()
        {
            var mEMBER = db.MEMBER.Include(m => m.PERSON);
            return View(await mEMBER.ToListAsync());
        }

        // GET: MEMBERs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBER mEMBER = await db.MEMBER.FindAsync(id);
            if (mEMBER == null)
            {
                return HttpNotFound();
            }
            return View(mEMBER);
        }

        // GET: MEMBERs/Create
        public ActionResult Create()
        {
            ViewBag.CITIZENID = new SelectList(db.PERSON, "CITIZENID", "FNAME");
            return View();
        }

        // POST: MEMBERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MEMBERID,STARTDATE,EXPIRYDATE,CITIZENID")] MEMBER mEMBER)
        {
            if (ModelState.IsValid)
            {
                db.MEMBER.Add(mEMBER);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CITIZENID = new SelectList(db.PERSON, "CITIZENID", "FNAME", mEMBER.CITIZENID);
            return View(mEMBER);
        }

        // GET: MEMBERs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBER mEMBER = await db.MEMBER.FindAsync(id);
            if (mEMBER == null)
            {
                return HttpNotFound();
            }
            ViewBag.CITIZENID = new SelectList(db.PERSON, "CITIZENID", "FNAME", mEMBER.CITIZENID);
            return View(mEMBER);
        }

        // POST: MEMBERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MEMBERID,STARTDATE,EXPIRYDATE,CITIZENID")] MEMBER mEMBER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mEMBER).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CITIZENID = new SelectList(db.PERSON, "CITIZENID", "FNAME", mEMBER.CITIZENID);
            return View(mEMBER);
        }

        // GET: MEMBERs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBER mEMBER = await db.MEMBER.FindAsync(id);
            if (mEMBER == null)
            {
                return HttpNotFound();
            }
            return View(mEMBER);
        }

        // POST: MEMBERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MEMBER mEMBER = await db.MEMBER.FindAsync(id);
            db.MEMBER.Remove(mEMBER);
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
