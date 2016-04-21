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
      public class DBInitializer : DropCreateDatabaseAlways<SARDTContext>
    //public class DBInitializer : DropCreateDatabaseIfModelChanges<SARDTContext>
    {
        protected override void Seed(SARDTContext context)
        {
            //TODO: Add seeds to context here. 
            //context.class.Add(newObjName)
            WebText homeText = new WebText { WebTextID = 0, Page = "Home", Section = "Welcome", Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText homeText1 = new WebText { WebTextID = 1, Page = "Home", Section = "News", Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText homeText2 = new WebText { WebTextID = 2, Page = "Home", Section = "Announcements", Body = "Announcements, Announcements, Announcements...please?", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            context.WebTexts.Add(homeText);
            context.WebTexts.Add(homeText1);
            context.WebTexts.Add(homeText2);

            WebText aboutText = new WebText { WebTextID = 6, Page="Team", Section = "About", Body = "Info about the dive team", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            context.WebTexts.Add(aboutText);

            WebText historyText = new WebText { WebTextID = 7, Page="History", Section = "History of the Dive Team", Body = "A long long time ago...in a galaxy far away...", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            context.WebTexts.Add(historyText);

            WebText contactText1 = new WebText { WebTextID = 8, Page = "Contact", Section = "Name", Body = "Contact Me", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText contactText2 = new WebText { WebTextID = 9, Page = "Contact", Section = "Email", Body = "something@something.com", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText contactText3 = new WebText { WebTextID = 10, Page = "Contact", Section = "Phone", Body = "541-123-4567", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText contactText4 = new WebText { WebTextID = 11, Page = "Contact", Section = "Address", Body = "Downtown Eugene", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            context.WebTexts.Add(contactText1);
            context.WebTexts.Add(contactText2);
            context.WebTexts.Add(contactText3);
            context.WebTexts.Add(contactText4);

            WebText applicationText0 = new WebText { WebTextID = 3, Page = "Application", Section = "1", Body = "App part 1", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText applicationText1 = new WebText { WebTextID = 4, Page = "Application", Section = "2", Body = "App part 2", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText applicationText2 = new WebText { WebTextID = 5, Page = "Application", Section = "3", Body = "App part 3", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            context.WebTexts.Add(applicationText0);
            context.WebTexts.Add(applicationText1);
            context.WebTexts.Add(applicationText2);

            WebImage image1 = new WebImage { WebImageID = 0, FileName = "pic1.jpg", Caption = "Image Caption1", InUse = true, Location="Home"};
            WebImage image2 = new WebImage { WebImageID = 1, FileName = "pic2.jpg", Caption = "Image Caption2", InUse = true, Location = "Home" };
            WebImage image3 = new WebImage { WebImageID = 2, FileName = "pic3.jpg", Caption = "Image Caption3", InUse = false, Location = "" };
            WebImage image4 = new WebImage { WebImageID = 3, FileName = "pic3.jpg", Caption = "Image Caption4", InUse = false, Location = "" };
            WebImage image5 = new WebImage { WebImageID = 4, FileName = "pic3.jpg", Caption = "Image Caption5", InUse = false, Location = "" };
            context.WebImages.Add(image1);
            context.WebImages.Add(image2);
            context.WebImages.Add(image3);
            context.WebImages.Add(image4);
            context.WebImages.Add(image5);

            Member firstMember = new Member { MemberID=1, Address = "1825 donald street", AttendencePercent = 20, City = "Eugene", DOB = "04/05/1978", Email = "Karrill29@gmail.com", LastName = "Swearingen", FirstName = "Quiante", IsDiveEligible = true , EmergencyContact = "Becky Swearingen 541-337-5208", HomeNumber = 541 - 222 - 2222, ZipCode = 97405, WorkPhone = 000 - 000 - 0000 };

            Video seedVid = new Video { ID = 2, Title = "Insert Title", URL = "https://www.youtube.com/embed/6OHmn4Tcfd4?rel=0" };
            context.Videos.Add(seedVid);
            CurrentVideos video = new CurrentVideos { CurrentVideo = seedVid, ID = 2};
            context.CurrentVideo.Add(video);

            context.SaveChanges();
            base.Seed(context);
            
        }
    }
}