namespace SARDT.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SARDT.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<SARDT.Models.SARDTContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SARDT.Models.SARDTContext";
        }

        protected override void Seed(SARDT.Models.SARDTContext context)
        {

            UserManager<Member> userManager = new UserManager<Member>(
                  new UserStore<Member>(context));

            WebText homeText = new WebText { WebTextID = 0, Page = "Home", Section = "Welcome", Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText homeText1 = new WebText { WebTextID = 1, Page = "Home", Section = "News", Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText homeText2 = new WebText { WebTextID = 2, Page = "Home", Section = "Announcements", Body = "Announcements, Announcements, Announcements...please?", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            context.WebTexts.AddOrUpdate(homeText);
            context.WebTexts.AddOrUpdate(homeText1);
            context.WebTexts.AddOrUpdate(homeText2);

            WebText aboutText = new WebText { WebTextID = 6, Page = "Team", Section = "About", Body = "Info about the dive team", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            context.WebTexts.AddOrUpdate(aboutText);

            WebText historyText = new WebText { WebTextID = 7, Page = "History", Section = "History of the Dive Team", Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText historyText1 = new WebText { WebTextID = 20, Page = "History", Section = "Where it started...", Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            context.WebTexts.AddOrUpdate(historyText);
            context.WebTexts.AddOrUpdate(historyText1);


            WebText contactText1 = new WebText { WebTextID = 8, Page = "Contact", Section = "Expected Response", Body = "This can be a generic message...once contacted you can expect a response within a certian amount of time...", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText contactText2 = new WebText { WebTextID = 9, Page = "Contact", Section = "Name", Body = "Jessica Watson", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText contactText3 = new WebText { WebTextID = 10, Page = "Contact", Section = "Email", Body = "Jessica.Watson@co.lane.or.us", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText contactText4 = new WebText { WebTextID = 11, Page = "Contact", Section = "Phone", Body = "541-682-6411", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText contactText5 = new WebText { WebTextID = 12, Page = "Contact", Section = "Fax", Body = "541-682-3309", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText contactText6 = new WebText { WebTextID = 13, Page = "Contact", Section = "Address", Body = "125 E 8th Ave", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText contactText7 = new WebText { WebTextID = 14, Page = "Contact", Section = "City", Body = "Eugene", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText contactText8 = new WebText { WebTextID = 15, Page = "Contact", Section = "State", Body = "OR", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText contactText9 = new WebText { WebTextID = 16, Page = "Contact", Section = "Zip", Body = "97401", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText contactText10 = new WebText { WebTextID = 17, Page = "Contact", Section = "Map URL", Body = "https://www.google.com/maps/d/embed?mid=1eeqA5dx0Qtw9GB6zqbfBlOk8hCI", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            context.WebTexts.AddOrUpdate(contactText1);
            context.WebTexts.AddOrUpdate(contactText2);
            context.WebTexts.AddOrUpdate(contactText3);
            context.WebTexts.AddOrUpdate(contactText4);
            context.WebTexts.AddOrUpdate(contactText5);
            context.WebTexts.AddOrUpdate(contactText6);
            context.WebTexts.AddOrUpdate(contactText7);
            context.WebTexts.AddOrUpdate(contactText8);
            context.WebTexts.AddOrUpdate(contactText9);
            context.WebTexts.AddOrUpdate(contactText10);


            WebText applicationText0 = new WebText { WebTextID = 3, Page = "Application", Section = "Requirements", Body = "A summary of steps and requirements. Such as background check, fingerprint, rescue cert, probationary period, current fa/cpr...", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText applicationText1 = new WebText { WebTextID = 4, Page = "Application", Section = "1", Body = "Fill out and return the application form.", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText applicationText2 = new WebText { WebTextID = 5, Page = "Application", Section = "2", Body = "App part 2", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText applicationText3 = new WebText { WebTextID = 18, Page = "Application", Section = "3", Body = "App part 3", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText applicationText4 = new WebText { WebTextID = 19, Page = "Application", Section = "4", Body = "App part 4", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            context.WebTexts.AddOrUpdate(applicationText0);
            context.WebTexts.AddOrUpdate(applicationText1);
            context.WebTexts.AddOrUpdate(applicationText2);
            context.WebTexts.AddOrUpdate(applicationText3);
            context.WebTexts.AddOrUpdate(applicationText4);

            Application app = new Application { ApplicationID = 0, FileName = "Application.pdf" };
            context.Applications.AddOrUpdate(app);

            WebImage image1 = new WebImage { WebImageID = 0, FileName = "pic1.jpg", Caption = "Image Caption1", InUse = true, Page = "Home", Location = 1 };
            WebImage image2 = new WebImage { WebImageID = 1, FileName = "pic2.jpg", Caption = "Image Caption2", InUse = true, Page = "Home", Location = 2 };
            WebImage image3 = new WebImage { WebImageID = 2, FileName = "pic3.jpg", Caption = "Image Caption3", InUse = true, Page = "History", Location = 1 };
            WebImage image4 = new WebImage { WebImageID = 3, FileName = "pic4.jpg", Caption = "Image Caption4", InUse = true, Page = "History", Location = 2 };
            WebImage image5 = new WebImage { WebImageID = 4, FileName = "pic5.jpg", Caption = "Image Caption5", InUse = false, Page = "", Location = null };
            context.WebImages.AddOrUpdate(image1);
            context.WebImages.AddOrUpdate(image2);
            context.WebImages.AddOrUpdate(image3);
            context.WebImages.AddOrUpdate(image4);
            context.WebImages.AddOrUpdate(image5);

            Video seedVid = new Video { ID = 2, Title = "Insert Title", URL = "https://www.youtube.com/embed/6OHmn4Tcfd4?rel=0" };
            context.Videos.AddOrUpdate(seedVid);
            CurrentVideos video = new CurrentVideos { CurrentVideo = seedVid, ID = 2 };
            context.CurrentVideo.AddOrUpdate(video);


            // create various users
            var userAdmin = new Member { UserName = "admin", Email = "admin@gmail.com", Name = "Admin Johnson" };
            var adminCreateResult = userManager.Create(userAdmin, "password");

            var userMod = new Member { UserName = "moderator", Email = "moderator@gmail.com", Name = "Moderator Stevens" };
            var modCreateResult = userManager.Create(userMod, "password");

            var userBob = new Member { UserName = "bob", Email = "bob@gmail.com", Name = "Bob Dylan" };
            var bobCreateResult = userManager.Create(userBob, "password");

            var userGuy = new Member { UserName = "guy", Email = "guy@gmail.com", Name = "Guy Pierce" };
            var guyCreateResult = userManager.Create(userGuy, "password");

            // Add all roles
            context.Roles.AddOrUpdate(new IdentityRole() { Name = "Admin" });
            context.Roles.AddOrUpdate(new IdentityRole() { Name = "Moderator" });
            context.SaveChanges();

            // Add role to user
            userManager.AddToRole(userAdmin.Id, "Admin");
            userManager.AddToRole(userMod.Id, "Moderator");

            Event firstEvent = new Event { Description = "This is the first event!", StartTime = "1200", EndTime = "1400", EventDate = Convert.ToDateTime("04/30/2016"), EventTitle = "First Event", LastChangeBy = "guy", LastChangedOn = Convert.ToDateTime("04/30/2016"), Type = "public" };

            Event secondEvent = new Event { Description = "Second event here!", StartTime = "0800", EndTime = "1000", EventDate = Convert.ToDateTime("04/21/2016"), EventTitle = "Second Event", LastChangeBy = "dude", LastChangedOn = Convert.ToDateTime("04/21/2016"), Type = "public" };

            Event thirdEvent = new Event { Description = "WOOOHOOO!", StartTime = "1700", EndTime = "2000", EventDate = Convert.ToDateTime("05/10/2016"), EventTitle = "Last Event", LastChangeBy = "person", LastChangedOn = Convert.ToDateTime("05/10/2016"), Type = "team" };

            context.Events.AddOrUpdate(firstEvent);
            context.Events.AddOrUpdate(secondEvent);
            context.Events.AddOrUpdate(thirdEvent);

            context.SaveChanges();
            base.Seed(context);

        }
    }
}
