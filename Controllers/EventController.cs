using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventMVC.Models;
using System.Web.Security;

namespace EventMVC.Controllers
{
    public class EventController : Controller
    {
        private EventDBContext db = new EventDBContext();

        //
        // GET: /Event/

        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }

        //
        // GET: /Event/Details/5

        public ActionResult Details(int id = 0)
        {
            if (User.IsInRole("Admin"))
            {
                Event _event = db.Events.Find(id);
                if (_event == null)
                {
                    return HttpNotFound();
                }
                return View(_event);
            }
            return null;
        }

        //
        // GET: /Event/Create

        public ActionResult Create()
        {
            if (User.IsInRole("Admin"))
            {
                return View();
            }
            return null;
        }

        //
        // POST: /Event/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event _event)
        {
            if (User.IsInRole("Admin"))
            {
                if (ModelState.IsValid)
                {
                    db.Events.Add(_event);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(_event);
            }
            return null;
        }

        //
        // GET: /Event/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (User.IsInRole("Admin"))
            {
                Event _event = db.Events.Find(id);
                if (_event == null)
                {
                    return HttpNotFound();
                }
                return View(_event);
            }
            return null;
        }

        //
        // POST: /Event/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event _event)
        {
            if (User.IsInRole("Admin"))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(_event).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(_event);
            }
            return null;
        }

        //
        // GET: /Event/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (User.IsInRole("Admin"))
            {
                Event _event = db.Events.Find(id);
                if (_event == null)
                {
                    return HttpNotFound();
                }
                return View(_event);
            }
            return null;
        }

        //
        // POST: /_event/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (User.IsInRole("Admin"))
            {
                Event _event = db.Events.Find(id);
                db.Events.Remove(_event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return null;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}