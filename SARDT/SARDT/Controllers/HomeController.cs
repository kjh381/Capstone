using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SARDT.Models;

namespace SARDT.Controllers
{
    public class HomeController : Controller
    {


        private SARDTContext db = new SARDTContext();


        // GET: Home
        public ActionResult Index()
        {
            WebText home = (from s in db.WebTexts
                               where s.Section == "Home"
                               select s).FirstOrDefault();

            ViewBag.BodyText = home.Body;

            List<String> publicEvents = new List<String>();

            //foreach (Event e in db.Events)
            //{
            //    var events = (from ev in db.Events
            //                    where ev.Type == "public"
            //                        select ev.EventTitle);

            //    string showEvent = events.ToString();

            //    publicEvents.Add(showEvent);
            //}

            var events = from ev in db.Events
                         where ev.Type == "public"
                         select ev;

            foreach (var e in events)
            {
                var eventDate = e.EventDate.Date;
                var eventTime = ParseMilitaryTime(e.StartTime.ToString());

                publicEvents.Add(eventDate.ToString("d") + " " + e.EventTitle + " " + eventTime.ToString("t"));
            }
        
            ViewBag.EventsText = publicEvents;

            Video currentVideo = new Video();
            currentVideo.Title = "invalid";
            currentVideo.URL = "invalid";
            if (db.CurrentVideo.Count() > 0)
                currentVideo = db.CurrentVideo.Include("CurrentVideo").FirstOrDefault().CurrentVideo;

            return View(currentVideo);

        }

        public ActionResult Team()
        {
            return View();
        }

        public ActionResult History()
        {
            WebText history = (from s in db.WebTexts
                               where s.Section == "History"
                               select s).FirstOrDefault();

            ViewBag.BodyText = history.Body;

            return View();
        }

        public ActionResult Member()
        {
            return View();
        }

        public ActionResult Donate()
        {
            return View();
        }

        public ActionResult Application()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public static DateTime ParseMilitaryTime(string time)
        {
	    //
	    // Convert hour part of string to integer.
	    //
	    string hour = time.Substring(0, 2);
	    int hourInt = int.Parse(hour);
	    if (hourInt >= 24)
	    {
	        throw new ArgumentOutOfRangeException("Invalid hour");
	    }
	    //
	    // Convert minute part of string to integer.
	    //
	    string minute = time.Substring(2, 2);
	    int minuteInt = int.Parse(minute);
	    if (minuteInt >= 60)
	    {
	        throw new ArgumentOutOfRangeException("Invalid minute");
	    }
	    //
	    // Return the DateTime.
	    //
	    return new DateTime(2016, 04, 20, hourInt, minuteInt, 0);
        }


    }
}