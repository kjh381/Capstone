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

        // GET: /Calendar/5
        public ActionResult Index(int? year, int? month)
        {
            CalendarVM calendarVM;
            if (month == null || year == null)
            {
                DateTime currentDate = DateTime.Now;
                calendarVM = CreateCalendarFromDate(currentDate.Year, currentDate.Month);
                return View(calendarVM);
            }
            calendarVM = CreateCalendarFromDate((int)year, (int)month);
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

        private CalendarVM CreateCalendarFromDate(int year, int month)
        {
            string dateString = month.ToString("##") + "/01/" + year.ToString("##");
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
                newDay.Date = date;
                newDay.Events = (from e in db.Events
                                    where e.EventDate == date
                                    select e).OrderBy(thisEvent => thisEvent.StartTime).ToList();
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
