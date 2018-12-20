using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class MovieController : Controller
    {
        private MoviesDBEntities db = new MoviesDBEntities();
        // GET: Movie
        public ActionResult Index()
        {
            return View(db.Movies1.ToList());
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            Movie movie = db.Movies1.Find(id);
            return View(movie);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                db.Movies1.Add(movie);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            var movieEdit = db.Movies1.Where(c => c.Id == id).First();
            return View(movieEdit);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            try
            {
                var movieToChange = db.Movies1.Where(t => t.Id == movie.Id).First();
                movieToChange.Title = movie.Title;
                movieToChange.Director = movie.Director;
                movieToChange.DateReleased = movie.DateReleased;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            var movieDelete = db.Movies1.Where(c => c.Id == id).First();
            return View(movieDelete);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(Movie movie)
        {
            try
            {
                var movieToDelete = db.Movies1.Where(m => m.Id == movie.Id).First();
                db.Movies1.Remove(movieToDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /* THIS IS MICROSOFT'S BEAUTIFUL SOLUTION
         * https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/examining-the-details-and-delete-methods
         * // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
*/
    }
}
