using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCs00130835_CA2.Models;

namespace MVCs00130835_CA2.Controllers
{
    public class HomeController : Controller
    {
        public IMDb Db = new IMDb();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            //ViewBag.Count.Acting = db.Actors.Count(); 

            ViewBag.PageTitle = "List Of Films (Total Actors: " + Db.Actors.Count() + ")";

            return View(Db.Movies.OrderBy(m => m.Title).ToList());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id = 0)
        {
            Movie movie = Db.Movies.Find(id);
            if (movie == null)
            {
                return View();
            }
            else
            {
                return View(movie);
            }
        }
        //
        // GET: /Home/Create

        public ActionResult AddActor(int id = 0)
        {
            ViewBag.Actor = new SelectList(Db.Actors, "ActorId", "Name");
            return View(Db.Movies.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddActor(Movie ActorFilmCredits)
        {
                Db.Movies.Add(ActorFilmCredits);
                Db.SaveChanges();
                return RedirectToAction("Details");
        }

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                Db.Movies.Add(movie);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Movie movie = Db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(movie).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Movie movie = Db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = Db.Movies.Find(id);
            Db.Movies.Remove(movie);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            Db.Dispose();
            base.Dispose(disposing);
        }
    }
}