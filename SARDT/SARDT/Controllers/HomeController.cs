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
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Team()
        {
            return View();
        }

        public ActionResult History()
        {
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