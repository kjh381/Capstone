﻿using System;
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
            PublicVM pageContent = GetPageContent("Home", true, "");
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
            PublicVM pageContent = GetPageContent("Contact", false, "");
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

            pageContent.textList = (from s in db.WebTexts
                                    where s.Page == pageName
                                    select s).ToList();

            pageContent.imageList = (from i in db.WebImages
                                     where i.Page == pageName
                                     orderby i.Location
                                     select i).ToList();

            return (pageContent);
        }

    }
}