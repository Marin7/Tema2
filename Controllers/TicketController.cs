using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventMVC.Models;

namespace EventMVC.Controllers
{
    public class TicketController : Controller
    {
        private EventDBContext db = new EventDBContext();

        //
        // GET: /Ticket/

        public ActionResult Index()
        {
            var tickets = db.Tickets.Include(t => t.Event);
            return View(tickets.ToList());
        }

        //
        // GET: /Ticket/Details/5

        public ActionResult Details(int id = 0)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        //
        // GET: /Ticket/Create

        public ActionResult Create()
        {
            ViewBag.EventID = new SelectList(db.Events, "ID", "title");
            return View();
        }

        //
        // POST: /Ticket/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventID = new SelectList(db.Events, "ID", "title", ticket.EventID);
            return View(ticket);
        }

        //
        // GET: /Ticket/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventID = new SelectList(db.Events, "ID", "title", ticket.EventID);
            return View(ticket);
        }

        //
        // POST: /Ticket/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.Events, "ID", "title", ticket.EventID);
            return View(ticket);
        }

        //
        // GET: /Ticket/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        //
        // POST: /Ticket/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}