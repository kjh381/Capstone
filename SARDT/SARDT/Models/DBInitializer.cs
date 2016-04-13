﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SARDT.Models;

namespace SARDT.Models
{
    public class DBInitializer : DropCreateDatabaseAlways<SARDTContext>
    //public class DBInitializer : DropCreateDatabaseIfModelChanges<SARDTContext>
    {
        protected override void Seed(SARDTContext context)
        {
            //TODO: Add seeds to context here. 
            //context.class.Add(newObjName)
            WebText homeText = new WebText{ WebTextID = 0, Section="Home", Body = "Here is some test text for the home page", LastChangedOn=new DateTime(2016,4,2), LastChangeBy="Kyle"};
            context.WebTexts.Add(homeText);

            WebText aboutText = new WebText { WebTextID = 1, Section = "About", Body = "Info about the dive team", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            context.WebTexts.Add(aboutText);

            WebText historyText = new WebText { WebTextID = 2, Section = "History", Body = "History of the dive team", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            context.WebTexts.Add(historyText);

            Event firstEvent = new Event { Description = "This is the first event!", StartTime = 1200, EndTime = 1400, EventDate = Convert.ToDateTime("04/30/2016"), EventTitle = "First Event", LastChangeBy = "guy", LastChangedOn = Convert.ToDateTime("04/30/2016"), Type = Event.EventType.Public };

            Event secondEvent = new Event { Description = "Second event here!", StartTime = 800, EndTime = 1000, EventDate = Convert.ToDateTime("04/21/2016"), EventTitle = "Second Event", LastChangeBy = "dude", LastChangedOn = Convert.ToDateTime("04/21/2016"), Type = Event.EventType.Public };

            Event thirdEvent = new Event { Description = "WOOOHOOO!", StartTime = 1700, EndTime = 2000, EventDate = Convert.ToDateTime("05/10/2016"), EventTitle = "Last Event", LastChangeBy = "person", LastChangedOn = Convert.ToDateTime("05/10/2016"), Type = Event.EventType.Private };

            context.Events.Add(firstEvent);
            context.Events.Add(secondEvent);
            context.Events.Add(thirdEvent);

            context.SaveChanges();
            base.Seed(context);
            
        }
    }
}