using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using nok_cinema_web.BLL;
using nok_cinema_web.Models;
using nok_cinema_web.ViewModels;
using System.Globalization;
using System.Web.Security;


namespace nok_cinema_web.Controllers
{
    public class MoviesController : Controller
    {       
        EMPLOYEE employee = new EMPLOYEE();
        MEMBER member = new MEMBER();
        PERSON person = new PERSON();
        MemberUserProfile memberuserProfile = new MemberUserProfile();
        EmployeeUserProfile employeeuserProfile = new EmployeeUserProfile();

        private CinemaEntities db = new CinemaEntities();

        // GET: Movies
        public async Task<ActionResult> Index()
        {
            return View(await db.MOVIE.ToListAsync());
        }        

        public ActionResult BrowseShowtimes(int movieid)
        {
            return RedirectToAction("Browse", "SHOWTIMEs", new { movieid });
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
        public async Task<ActionResult> Create([Bind(Include = "MOVIEID,MOVIENAME,DIRECTOR,SHORTDESCRIPTION,DURATION,PLAYCOUNT,STATUS,SHOWDATE")] MOVIE mOVIE)
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
        public async Task<ActionResult> Edit([Bind(Include = "MOVIEID,MOVIENAME,DIRECTOR,SHORTDESCRIPTION,DURATION,PLAYCOUNT,STATUS,SHOWDATE")] MOVIE mOVIE)
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

        public ActionResult Movie()
        {
            var movieBLL = new MoviesBLL();
            var movielist = new MovieListViewModel();
            movielist.Movies = movieBLL.GetMovieListByNowShowing();            

            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
                return View(movielist);
            else
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                DateTime expiration = ticket.Expiration;
                if (expiration < System.DateTime.Now)
                    return View(movielist);
                else
                {
                    string userName = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                    var peopleBLL = new PeopleBLL();
                    person = peopleBLL.GetPersonByCookie(userName);

                    var membersBLL = new MemberBLL();
                    member = membersBLL.GetMerberByCitizenId(person.CITIZENID);
                    if (member.EXPIRYDATE > DateTime.Now)
                    {
                        memberuserProfile = new MemberUserProfile(member, person);
                        TempData["UserProfileData"] = memberuserProfile;                        
                        return View("MovieWithLogin", movielist);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        [HttpPost]
        public ActionResult Search(string searchstr)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            searchstr = textInfo.ToTitleCase(searchstr);
            
            var movieBLL = new MoviesBLL();
            var movieList = new MovieListViewModel();
            movieList.Movies = movieBLL.GetMovieListBySearch(searchstr);
            if (movieList.Movies.Any())
            {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null)
                    return View("Search", movieList);
                else
                {
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                    DateTime expiration = ticket.Expiration;
                    if (expiration < System.DateTime.Now)
                        return View("Search", movieList);
                    else
                    {
                        string userName = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                        var peopleBLL = new PeopleBLL();
                        person = peopleBLL.GetPersonByCookie(userName);

                        var membersBLL = new MemberBLL();
                        member = membersBLL.GetMerberByCitizenId(person.CITIZENID);
                        if (member.EXPIRYDATE > DateTime.Now)
                        {
                            memberuserProfile = new MemberUserProfile(member, person);
                            TempData["UserProfileData"] = memberuserProfile;
                            return View("SearchWithLogin", movieList);
                        }
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                return RedirectToAction("Movie");
            }            
        }

        [HttpPost]
        public ActionResult Browse(string category)
        {
            var movieBLL = new MoviesBLL();
            var movieList = new MovieListViewModel();
            movieList.Category = new CATEGORY { CATEGORYNAME = category };
            movieList.Movies = movieBLL.GetMovieListByCategory(category);
            if (movieList.Movies.Any())
            {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null)
                    return View("Search", movieList);
                else
                {
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                    DateTime expiration = ticket.Expiration;
                    if (expiration < System.DateTime.Now)
                        return View("Search", movieList);
                    else
                    {
                        string userName = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                        var peopleBLL = new PeopleBLL();
                        person = peopleBLL.GetPersonByCookie(userName);

                        var membersBLL = new MemberBLL();
                        member = membersBLL.GetMerberByCitizenId(person.CITIZENID);
                        if (member.EXPIRYDATE > DateTime.Now)
                        {
                            memberuserProfile = new MemberUserProfile(member, person);
                            TempData["UserProfileData"] = memberuserProfile;
                            return View("SearchWithLogin", movieList);
                        }
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                return RedirectToAction("Movie");
            }
        }

        public ActionResult MovieDetail(int id)
        {
            var movieBLL = new MoviesBLL();
            var movie = new MovieViewModel();
            movie = movieBLL.GetMovieByMovieID(id);
            
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
                return View(movie);
            else
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                DateTime expiration = ticket.Expiration;
                if (expiration < System.DateTime.Now)
                    return View(movie);
                else
                {
                    string userName = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                    var peopleBLL = new PeopleBLL();
                    person = peopleBLL.GetPersonByCookie(userName);

                    var membersBLL = new MemberBLL();
                    member = membersBLL.GetMerberByCitizenId(person.CITIZENID);
                    if (member.EXPIRYDATE > DateTime.Now)
                    {
                        memberuserProfile = new MemberUserProfile(member, person);
                        TempData["UserProfileData"] = memberuserProfile;
                        return View("MovieDetailWithLogin", movie);
                    }
                    return RedirectToAction("Movie");
                }
            }
        }

        [Authorize]
        public ActionResult SelectMovie()
        {
            var movieBLL = new MoviesBLL();
            var movielist = new MovieListViewModel();
            movielist.Movies = movieBLL.GetMovieListByNowShowing();
            var employeesBLL = new EmployeesBLL();
            employee = employeesBLL.GetEmployeeByCitizenId(person.CITIZENID);
            if (employee.JOBPOSITION != "Manager")
            {
                employeeuserProfile = new EmployeeUserProfile(employee, person);
                TempData["UserProfileData"] = employeeuserProfile;
                return View("SelectMovieEmployee", movielist);
            }
            else
                return RedirectToAction("Index", "Home");


        }
    }
}
