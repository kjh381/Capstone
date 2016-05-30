using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SARDT.Controllers;
using SARDT.Models;
using System.Web.Mvc;

namespace SARDT.Tests
{
    [TestClass]
    public class CalendarTests
    {
        private CalendarController calendarController = new CalendarController();
        private SARDTContext db = new SARDTContext();

        [TestInitialize]
        public void Initialize()
        {
            Event firstEvent = new Event { Description = "This is the first event!", StartTime = "1200", EndTime = "1400", EventDate = DateTime.Now, EventTitle = "First Event", LastChangeBy = "guy", LastChangedOn = Convert.ToDateTime("04/30/2016"), Type = "public" };

            Event secondEvent = new Event { Description = "Second event here!", StartTime = "0800", EndTime = "1000", EventDate = DateTime.Now.AddDays(1.0), EventTitle = "Second Event", LastChangeBy = "dude", LastChangedOn = Convert.ToDateTime("04/21/2016"), Type = "public" };

            Event thirdEvent = new Event { Description = "WOOOHOOO!", StartTime = "1700", EndTime = "2000", EventDate = DateTime.Now.AddDays(-1.0), EventTitle = "Last Event", LastChangeBy = "person", LastChangedOn = Convert.ToDateTime("05/10/2016"), Type = "team" };

            db.Events.Add(firstEvent);
            db.Events.Add(secondEvent);
            db.Events.Add(thirdEvent);
            db.SaveChanges();
        }

        [TestMethod]
        public void Calendar_Index()
        {
            var result = calendarController.Index() as ViewResult;
            var model = (CalendarVM)result.Model;
            Assert.AreEqual(model.Year, DateTime.Now.Year);
            Assert.AreEqual(model.Month.Num, DateTime.Now.Month);
            Assert.IsNotNull(model.Month.Days);
        }


        [TestMethod]
        public void Calendar_NextMonth()
        {
            var result = calendarController.NextMonth(DateTime.Now.Year, DateTime.Now.Month) as ViewResult;
            var model = (CalendarVM)result.Model;
            if (DateTime.Now.Month == 12)
            {
                Assert.AreEqual(model.Year, DateTime.Now.Year + 1);
                Assert.AreEqual(model.Month.Num, 1);
            }
            else
            {
                Assert.AreEqual(model.Year, DateTime.Now.Year);
                Assert.AreEqual(model.Month.Num, DateTime.Now.Month + 1);
            }
            Assert.IsNotNull(model.Month.Days);
        }

        [TestMethod]
        public void Calendar_PreviousMonth()
        {
            var result = calendarController.PreviousMonth(DateTime.Now.Year, DateTime.Now.Month) as ViewResult;
            var model = (CalendarVM)result.Model;
            if (DateTime.Now.Month == 1)
            {
                Assert.AreEqual(model.Year, DateTime.Now.Year - 1);
                Assert.AreEqual(model.Month.Num, 12);
            }
            else
            {
                Assert.AreEqual(model.Year, DateTime.Now.Year);
                Assert.AreEqual(model.Month.Num, DateTime.Now.Month - 1);
            }
            Assert.IsNotNull(model.Month.Days);
        }
    }
}
