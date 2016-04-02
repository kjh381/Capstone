using System;
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
            WebText homeText = new WebText{ WebTextID = 0, Section="home", Body = "Here is some test text for the home page", LastChangedOn=new DateTime(2016,4,2), LastChangeBy="Kyle"};
            context.WebTexts.Add(homeText);

            WebText aboutText = new WebText { WebTextID = 1, Section = "about", Body = "Info about the dive team", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            context.WebTexts.Add(aboutText);

            WebText historyText = new WebText { WebTextID = 2, Section = "History", Body = "History of the diveteam", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            context.WebTexts.Add(historyText);

            base.Seed(context);
            context.SaveChanges();
        }
    }
}