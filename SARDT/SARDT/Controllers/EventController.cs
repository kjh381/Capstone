using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SARDT.Models;

namespace SARDT.Controllers
{
    public class EventController : Controller
    {
        private SARDTContext db = new SARDTContext();

        // GET: /Event/
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }

        // GET: /Event/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }



        //Custom Create with Month, Day, Year passed in
        [Authorize]
        public ActionResult Create(int? month, int? day, int? year)
        {
            typeSelectList();
            if (month == null || day == null || year == null)
            {
                return View();
            }
            else
            {
                Event newEvent = new Event();
                string dateString = month.Value.ToString("##") + "/" + day.Value.ToString("##") + "/" + year.Value.ToString("##");
                DateTime date = Convert.ToDateTime(dateString);
                newEvent.EventDate = date;
                return View(newEvent);
            }
        }

        // POST: /Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EventID,Type,EventDate,StartTime,EndTime,EventTitle,Description,LastChangedOn,LastChangeBy")] Event @event, string EventType)
        {
            if (ModelState.IsValid)
            {
                Event newEvent = new Event() {
                    Type = EventType,
                    EventDate = @event.EventDate,
                    StartTime = @event.StartTime,
                    EndTime = @event.EndTime,
                    EventTitle = @event.EventTitle,
                    Description = @event.Description,
                    LastChangedOn = @event.LastChangedOn,
                    LastChangeBy = @event.LastChangeBy
                };

                db.Events.Add(newEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: /Event/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typeSelectList();
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: /Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EventID,Type,EventDate,StartTime,EndTime,EventTitle,Description")] Event @event)
        {
            if (ModelState.IsValid)
            {
                if (@event.Type == "public" || @event.Type == "team")
                {
                    db.Entry(@event).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Type must be public or team";
                }
            }
            return View(@event);
        }

        // GET: /Event/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: /Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
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

        private void typeSelectList()
        {
            ViewBag.EventType = new List<SelectListItem> {
                new SelectListItem { Text = "Public Events", Value = "public" },
                new SelectListItem { Text = "Team Events", Value = "team" }
            };
        }
    }
}
