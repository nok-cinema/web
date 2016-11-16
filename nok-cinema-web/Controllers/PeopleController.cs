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
    public class PeopleController : Controller
    {
        private CinemaEntities db = new CinemaEntities();

        // GET: People
        public async Task<ActionResult> Index()
        {
            return View(await db.PERSON.ToListAsync());
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

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CITIZENID,FNAME,LNAME,GENDER,BIRTHDATE,ADDRESS,EMAIL,USERNAME,PASSWORD")] PERSON pERSON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pERSON).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
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
    }
}
