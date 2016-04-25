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
            return View(db.Users.ToList());
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
    }
}