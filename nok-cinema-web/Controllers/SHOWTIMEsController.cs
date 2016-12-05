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
using nok_cinema_web.ViewModels;
using nok_cinema_web.BLL;

namespace nok_cinema_web.Controllers
{
    public class SHOWTIMEsController : Controller
    {
        private CinemaEntities db = new CinemaEntities();

        // GET: SHOWTIMEs
        public async Task<ActionResult> Index()
        {
            var sHOWTIME = db.SHOWTIME.Include(s => s.MOVIE).Include(s => s.THEATRE);
            return View(await sHOWTIME.ToListAsync());
        }

        public ActionResult Browse(int movieid)
        {
            var showtimeBLL = new ShowtimeBLL();
            var showtimeList = new ShowtimeListViewModel();
            showtimeList = showtimeBLL.GetMovieListByMovieid(movieid);
            if (showtimeList.SHOWTIMES.Any())
            {
                return View("ShowtimeBrowse", showtimeList);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult SelectShowtime(int m_id, DateTime sd, byte t_id)
        {
            var select = new ShowtimeViewModel(m_id, sd, t_id);
            return View("SelectShowtime", select);
        }

        // GET: SHOWTIMEs/Details/5
        public async Task<ActionResult> Details(DateTime id1, int? id2)
        {
            if (id1 == null | id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOWTIME sHOWTIME = await db.SHOWTIME.FindAsync(id1, id2);
            if (sHOWTIME == null)
            {
                return HttpNotFound();
            }
            return View(sHOWTIME);
        }

        // GET: SHOWTIMEs/Details/5
        public async Task<ActionResult> Seats(DateTime id1, int? id2)
        {
            if (id1 == null | id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOWTIME sHOWTIME = await db.SHOWTIME.FindAsync(id1, id2);
            if (sHOWTIME == null)
            {
                return HttpNotFound();
            }
            return View(sHOWTIME);
        }

        public ActionResult Seats(DateTime id1, int id2)
        {
            var seatsBLL = new SeatsBLL();
            var seatList = new SeatListViewModel();
            seatList = seatsBLL.GetSeatListByShowtime(id1, id2);

            if (seatList.Seats.Any())
            {
                return View(seatList);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: SHOWTIMEs/Create
        public ActionResult Create()
        {
            ViewBag.MOVIEID = new SelectList(db.MOVIE, "MOVIEID", "MOVIENAME");
            ViewBag.THEATREID = new SelectList(db.THEATRE, "THEATREID", "THEATREID");
            return View();
        }

        // POST: SHOWTIMEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SHOWDATE,MOVIEID,THEATREID")] SHOWTIME sHOWTIME)
        {
            if (ModelState.IsValid)
            {
                db.SHOWTIME.Add(sHOWTIME);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MOVIEID = new SelectList(db.MOVIE, "MOVIEID", "MOVIENAME", sHOWTIME.MOVIEID);
            ViewBag.THEATREID = new SelectList(db.THEATRE, "THEATREID", "THEATREID", sHOWTIME.THEATREID);
            return View(sHOWTIME);
        }

        // GET: SHOWTIMEs/Edit/5
        public async Task<ActionResult> Edit(DateTime id1, int? id2)
        {
            if (id1 == null | id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOWTIME sHOWTIME = await db.SHOWTIME.FindAsync(id1, id2);
            if (sHOWTIME == null)
            {
                return HttpNotFound();
            }
            ViewBag.MOVIEID = new SelectList(db.MOVIE, "MOVIEID", "MOVIENAME", sHOWTIME.MOVIEID);
            ViewBag.THEATREID = new SelectList(db.THEATRE, "THEATREID", "THEATREID", sHOWTIME.THEATREID);
            return View(sHOWTIME);
        }

        // POST: SHOWTIMEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SHOWDATE,MOVIEID,THEATREID")] SHOWTIME sHOWTIME)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sHOWTIME).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MOVIEID = new SelectList(db.MOVIE, "MOVIEID", "MOVIENAME", sHOWTIME.MOVIEID);
            ViewBag.THEATREID = new SelectList(db.THEATRE, "THEATREID", "THEATREID", sHOWTIME.THEATREID);
            return View(sHOWTIME);
        }

        // GET: SHOWTIMEs/Delete/5
        public async Task<ActionResult> Delete(DateTime id1, int? id2)
        {
            if (id1 == null | id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOWTIME sHOWTIME = await db.SHOWTIME.FindAsync(id1, id2);
            if (sHOWTIME == null)
            {
                return HttpNotFound();
            }
            return View(sHOWTIME);
        }

        // POST: SHOWTIMEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(DateTime id1, int? id2)
        {
            SHOWTIME sHOWTIME = await db.SHOWTIME.FindAsync(id1, id2);
            db.SHOWTIME.Remove(sHOWTIME);
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
