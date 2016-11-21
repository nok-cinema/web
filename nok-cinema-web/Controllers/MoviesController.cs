using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using nok_cinema_web.BLL;
using nok_cinema_web.Models;
using nok_cinema_web.ViewModels;

namespace nok_cinema_web.Controllers
{
    public class MoviesController : Controller
    {
        private CinemaEntities db = new CinemaEntities();

        // GET: Movies
        public async Task<ActionResult> Index()
        {
            return View(await db.MOVIE.ToListAsync());
        }

        public ActionResult Browse(string category)
        {
            var movieBLL = new MoviesBLL();
            var movieList = new MovieListViewModel();
            movieList.Category = category;
            movieList.Movies = movieBLL.GetMovieListByCategory(category);
            if (movieList.Movies.Any())
            {
                return this.View(movieList);
            }
            else
            {
                return View("Index");
            }
        }

        // GET: Movies/Details/5
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

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
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

        // GET: Movies/Edit/5
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

        // POST: Movies/Edit/5
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

        // GET: Movies/Delete/5
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

        // POST: Movies/Delete/5
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
