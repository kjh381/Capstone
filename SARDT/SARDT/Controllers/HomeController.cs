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
            PublicVM pageContent = GetPageContent("Home", true, "public");

            pageContent.eventList = (from c in pageContent.eventList
                                     orderby c.EventDate
                                     orderby c.StartTime
                                     select c).ToList();
            return View(pageContent);
        }

        public ActionResult Team()
        {
            return View();
        }

        public ActionResult History()
        {
            PublicVM pageContent = GetPageContent("History", false, "");
            return View(pageContent);
        }

        //[Authorize(Roles="Member, Admin")]
        public ActionResult Member()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Donate()
        {
            return View();
        }

        public ActionResult Application()
        {
            PublicVM pageContent = GetPageContent("Application", false, "");
            return View(pageContent);
        }

        public ActionResult Contact()
        {
            PublicVM pageContent = GetPageContent("Contact", false, "");
            
            pageContent.textList = (from c in pageContent.textList
                           orderby c.WebTextID
                           select c).ToList();
                         

            return View(pageContent);
        }


        private PublicVM GetPageContent(string pageName, bool getVideo, string getEvents)
        {
            PublicVM pageContent = new PublicVM();

            if (getEvents == "public")
            {
                pageContent.eventList = (from ev in db.Events
                                         where ev.Type == "public"
                                         select ev).ToList();
            }
            if (getEvents == "team")
            {
                pageContent.eventList = (from ev in db.Events
                                         where ev.Type == "team"
                                         select ev).ToList();
            }

            if (getVideo == true)
            {
                Video currentVideo = new Video();
                currentVideo.Title = "invalid";
                currentVideo.URL = "invalid";
                if (db.CurrentVideo.Count() > 0)
                    currentVideo = db.CurrentVideo.Include("CurrentVideo").FirstOrDefault().CurrentVideo;

                pageContent.currentVideo = currentVideo;
            }

            if (pageName == "Application")
            {
                pageContent.application = (from a in db.Applications
                                           select a).FirstOrDefault();            
            }

            pageContent.textList = (from s in db.WebTexts
                                    where s.Page == pageName
                                    select s).ToList();

            pageContent.imageList = (from i in db.WebImages
                                     where i.Page == pageName
                                     orderby i.Location
                                     select i).ToList();

            return (pageContent);
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