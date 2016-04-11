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
    public class CalendarController : Controller
    {
        private SARDTContext db = new SARDTContext();

        // GET: /Calendar/
        public ActionResult Index()
        {
            DateTime currentDate = DateTime.Now;
            CalendarVM calendarVM = CreateCalendarFromDate(currentDate.Year, currentDate.Month);

            return View(calendarVM);
        }

        // GET: /Calendar/PreviousMonth/5
        public ActionResult PreviousMonth(int? year, int? month)
        {
            if (month == null || year == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarVM calendarVM = CreatePreviousCalendarFromDate((int)year, (int)month);
            return View("Index", calendarVM);
        }


        // GET: /Calendar/NextMonth/5
        public ActionResult NextMonth(int? year, int? month)
        {
            if (month == null || year == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarVM calendarVM = CreateNextCalendarFromDate((int)year, (int)month);
            return View("Index", calendarVM);
        }

        /*
        // GET: /Calendar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Year year = db.Years.Find(id);
            if (year == null)
            {
                return HttpNotFound();
            }
            return View(year);
        }

        // GET: /Calendar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Calendar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Num")] Year year)
        {
            if (ModelState.IsValid)
            {
                db.Years.Add(year);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(year);
        }

        // GET: /Calendar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Year year = db.Years.Find(id);
            if (year == null)
            {
                return HttpNotFound();
            }
            return View(year);
        }

        // POST: /Calendar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Num")] Year year)
        {
            if (ModelState.IsValid)
            {
                db.Entry(year).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(year);
        }

        // GET: /Calendar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Year year = db.Years.Find(id);
            if (year == null)
            {
                return HttpNotFound();
            }
            return View(year);
        }

        // POST: /Calendar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Year year = db.Years.Find(id);
            db.Years.Remove(year);
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
        */
        private CalendarVM CreateCalendarFromDate(int year, int month)
        {
            string dateString = month.ToString("##") + "/01/" + year.ToString("##") + " 12:00:00.00";
            DateTime date = Convert.ToDateTime(dateString);
            CalendarVM calendar = new CalendarVM();
            calendar.Month.Num = month;
            calendar.Year = year;
            calendar.Month.DaysInMonth = DateTime.DaysInMonth(year, month);
            calendar.Month.Name = GetMonthName(month);
            int count = 0;
            while (date.Month == month)
            {
                Day newDay = new Day();
                newDay.Month = date.Month;
                newDay.DayOfWeek = (int)date.DayOfWeek;
                newDay.DayOfMonth = date.Day;
                calendar.Month.Days.Add(newDay);
                count++;
                date = date.AddDays(1.0);
            }
            return calendar;
        }

        private CalendarVM CreatePreviousCalendarFromDate(int year, int month)
        {
            month = month - 1;
            if (month < 1)
            {
                month = 12;
                year = year - 1;
            }
            return CreateCalendarFromDate(year, month);
        }

        private CalendarVM CreateNextCalendarFromDate(int year, int month)
        {
            month = month + 1;
            if (month > 12)
            {
                month = 1;
                year = year + 1;
            }
            return CreateCalendarFromDate(year, month);
        }

        private string GetDayName(int dayNum)
        {            string dayName = "";
            switch(dayNum)
            {
                case 0:
                    dayName = "Sunday";
                    break;
                case 1:
                    dayName = "Monday";
                    break;
                case 2:
                    dayName = "Tuesday";
                    break;
                case 3:
                    dayName = "Wednesday";
                    break;
                case 4:
                    dayName = "Thursday";
                    break;
                case 5:
                    dayName = "Friday";
                    break;
                case 6:
                    dayName = "Saturday";
                    break;
                default:
                    break;
            }
            return dayName;
        }


        private string GetMonthName(int monthNum)
        {
            string monthName = "";
            switch (monthNum)
            {
                case 1:
                    monthName = "January";
                    break;
                case 2:
                    monthName = "February";
                    break;
                case 3:
                    monthName = "March";
                    break;
                case 4:
                    monthName = "April";
                    break;
                case 5:
                    monthName = "May";
                    break;
                case 6:
                    monthName = "June";
                    break;
                case 7:
                    monthName = "July";
                    break;
                case 8:
                    monthName = "August";
                    break;
                case 9:
                    monthName = "September";
                    break;
                case 10:
                    monthName = "October";
                    break;
                case 11:
                    monthName = "November";
                    break;
                case 12:
                    monthName = "December";
                    break;
                default:
                    break;
            }
            return monthName;
        }
    }
}
