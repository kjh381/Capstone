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
            PublicVM pageContent = new PublicVM();

            Video currentVideo = new Video();
            currentVideo.Title = "invalid";
            currentVideo.URL = "invalid";
            if (db.CurrentVideo.Count() > 0)
                currentVideo = db.CurrentVideo.Include("CurrentVideo").FirstOrDefault().CurrentVideo;

            pageContent.currentVideo = currentVideo;

            pageContent.textList = (from t in db.WebTexts
                                    where t.Page == "Home"
                                    select t).ToList();

            pageContent.imageList = (from i in db.WebImages
                                     where i.Location == "Home"
                                     select i).ToList();

            return View(pageContent);

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
    }
}