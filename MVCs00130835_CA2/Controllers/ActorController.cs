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
    public class ActorController : Controller
    {
        private IMDb Db = new IMDb();

        //
        // GET: /Actor/

        public ActionResult Index()
        {
            return View(Db.Actors.ToList());
        }

        //
        // GET: /Actor/Details/5

        public ActionResult Details(int id = 0)
        {
            Actor actor = Db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        //
        // GET: /Actor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Actor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Actor actor)
        {
            if (ModelState.IsValid)
            {
                Db.Actors.Add(actor);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actor);
        }

        //
        // GET: /Actor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Actor actor = Db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        //
        // POST: /Actor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Actor actor)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(actor).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actor);
        }

        //
        // GET: /Actor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Actor actor = Db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        //
        // POST: /Actor/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actor actor = Db.Actors.Find(id);
            Db.Actors.Remove(actor);
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