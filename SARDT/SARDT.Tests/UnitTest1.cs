using System;
using SARDT.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace SARDT.Tests
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void GetTextPageContentTest()
        {
            string pageName = "Home";
            List<WebText> texts = new List<WebText>();
            WebText homeText = new WebText { WebTextID = 0, Page = "Home", Section = "Welcome", Body = "", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText homeText1 = new WebText { WebTextID = 1, Page = "Home", Section = "News", Body = "", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            WebText historyText = new WebText { WebTextID = 2, Page = "History", Section = "Announcements", Body = "", LastChangedOn = new DateTime(2016, 4, 2), LastChangeBy = "Kyle" };
            texts.Add(homeText);
            texts.Add(homeText);
            texts.Add(historyText);

            //act
            var testList = (from s in texts
                           where s.Page == pageName
                           select s).ToList();
            int count = testList.Count();
            int expected = 2;

            pageName = "History";
            var testList2 = (from s in texts
                             where s.Page == pageName
                             select s).ToList();
            int count2 = testList2.Count();
            int expected2 = 1;
                      
            //assert
            Assert.AreEqual(expected, count);
            Assert.AreEqual(expected2, count2);
            Assert.AreEqual("Announcements", testList2[0].Section);
        }

        [TestMethod]
        public void GetImagesPageContentTest()
        {
            List<WebImage> images = new List<WebImage>();
            WebImage img1 = new WebImage { FileName = "pic1", InUse = true, Page = "Home", Location= 1, Caption="Hi" };
            WebImage img2 = new WebImage { FileName = "pic2", InUse = true, Page = "Home", Location = 2, Caption = "Hello" };
            WebImage img3 = new WebImage { FileName = "pic3", InUse = false, Page = "", Location = null, Caption = "nope" };
            WebImage img4 = new WebImage { FileName = "pic4", InUse = false, Page = "", Location = null, Caption = "no captions here" };
            WebImage img5 = new WebImage { FileName = "pic5", InUse = false, Page = "", Location = null, Caption = "no captions here either" };
            images.Add(img1); images.Add(img2); images.Add(img3); images.Add(img4); images.Add(img5);

            //act
            string pageName = "Home";
            var testList = (from s in images
                            where s.Page == pageName
                            select s).ToList();

            var inUseImages = (from s in images
                            where s.InUse == true
                            select s).ToList();

            //assert
            Assert.AreEqual(5, images.Count());
            Assert.AreEqual(2, testList.Count());
            Assert.AreEqual(2, inUseImages.Count());
        
        }
        [TestMethod]
        public void ChangeActiveImageTest() 
        {
            WebImage img1 = new WebImage { FileName = "pic1", InUse = true, Page = "Home", Location = 1, Caption = "Hi" };
            WebImage img2 = new WebImage { FileName = "pic2", InUse = true, Page = "Home", Location = 2, Caption = "Hello" };
            WebImage img3 = new WebImage { FileName = "pic3", InUse = false, Page = "", Location = null, Caption = "nope" };


            //act
            WebImage nowActive = img3;
            WebImage oldImage = img1;

            nowActive.InUse = true;
            oldImage.InUse = false;
            nowActive.Page = oldImage.Page;
            oldImage.Page = "";

            nowActive.Location = oldImage.Location;
            oldImage.Location = null;
            
        
            //assert
            Assert.AreEqual(img1.Caption, "Hi");
            Assert.AreEqual(img1.InUse, false);
            Assert.AreEqual(img3.InUse, true);
            Assert.AreEqual(img3.Page, "Home");
            Assert.AreEqual(img3.Location, 1);
        
        }
    }
}
