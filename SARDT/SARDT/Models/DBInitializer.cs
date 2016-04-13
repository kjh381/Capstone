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
            WebText homeText = new WebText{ WebTextID = 0, Page="Home", Section="Home", Body = "Here is some test text for the home page", LastChangedOn=new DateTime(2016,4,2), LastChangeBy="Kyle"};
            context.WebTexts.Add(homeText);

            WebText aboutText = new WebText { WebTextID = 1, Page="Team", Section = "About", Body = "Info about the dive team", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            context.WebTexts.Add(aboutText);


            WebText historyText = new WebText { WebTextID = 2, Page="History", Section = "History", Body = "History of the dive team", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            context.WebTexts.Add(historyText);

            WebText applicationText0 = new WebText { WebTextID = 3, Page = "Application", Section = "1", Body = "App part 1", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText applicationText1 = new WebText { WebTextID = 4, Page = "Application", Section = "2", Body = "App part 2", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText applicationText2 = new WebText { WebTextID = 5, Page = "Application", Section = "3", Body = "App part 3", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            context.WebTexts.Add(applicationText0);
            context.WebTexts.Add(applicationText1);
            context.WebTexts.Add(applicationText2);

            WebImage image1 = new WebImage { WebImageID = 0, FileName = "pic1.jpg", Caption = "Image Caption1", InUse = true, Location="Home"};
            WebImage image2 = new WebImage { WebImageID = 1, FileName = "pic2.jpg", Caption = "Image Caption2", InUse = false, Location = "Test" };
            WebImage image3 = new WebImage { WebImageID = 3, FileName = "pic3.jpg", Caption = "Image Caption3", InUse = false, Location = "" };
            WebImage image4 = new WebImage { WebImageID = 4, FileName = "pic3.jpg", Caption = "Image Caption4", InUse = false, Location = "" };
            WebImage image5 = new WebImage { WebImageID = 5, FileName = "pic3.jpg", Caption = "Image Caption5", InUse = false, Location = "" };
            context.WebImages.Add(image1);
            context.WebImages.Add(image2);
            context.WebImages.Add(image3);
            context.WebImages.Add(image4);
            context.WebImages.Add(image5);

            WebText historyText = new WebText { WebTextID = 2, Section = "History", Body = "History of the dive team", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };

            Member firstMember = new Member { MemberID=1, Address = "1825 donald street", AttendencePercent = 20, City = "Eugene", DOB = "04/05/1978", Email = "Karrill29@gmail.com", LastName = "Swearingen", FirstName = "Quiante", IsDiveEligible = true , EmergencyContact = "Becky Swearingen 541-337-5208", HomeNumber = 541 - 222 - 2222, ZipCode = 97405, WorkPhone = 000 - 000 - 0000 };
            
            //context.Users.Add();
            context.WebTexts.Add(historyText);


            context.SaveChanges();
            base.Seed(context); 
            
        }
    }
}