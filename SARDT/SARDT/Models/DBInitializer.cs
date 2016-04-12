using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;

//using SARDT.Models;

namespace SARDT.Models
{
   // public class DBInitializer : DropCreateDatabaseAlways<SARDTContext>
    public class DBInitializer : DropCreateDatabaseIfModelChanges<SARDTContext>
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
            

            Member firstMember = new Member { MemberID=1, Address = "1825 donald street", AttendencePercent = 20, City = "Eugene", DOB = "04/05/1978", Email = "Karrill29@gmail.com", LastName = "Swearingen", FirstName = "Quiante", IsDiveEligible = true , EmergencyContact = "Becky Swearingen 541-337-5208", HomeNumber = 541 - 222 - 2222, ZipCode = 97405, WorkPhone = 000 - 000 - 0000 };
            
            //context.Users.Add();
            context.WebTexts.Add(historyText);
            context.SaveChanges();
            base.Seed(context); 
            
        }
    }
}