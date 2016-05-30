using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SARDT.Controllers;
using SARDT.Models;
using System.Web.Mvc;

namespace SARDT.Tests
{
    [TestClass]
    public class VideoTests
    {
        VideosController videoController = new VideosController();
        SARDTContext db = new SARDTContext();

        [TestMethod]
        public void Video_Scrubber()
        {
            string url1 = "https://www.youtube.com/watch?v=tRMZ2Icpz6s";
            string url2 = "https://www.youtube.com/watch?v=Y-orMndwuSE&ebc=ANyPxKoSFuYCSPtESFOr9_j-I_YrR1Ewk8Z9892MNtjkq5CwqNMuKpqWeofe0Y0urZGuufnUg_-rEmMygvqfv9dtiOoNhEmZiw";
            string url3 = "tRMZ2Icpz6s";

            Assert.AreEqual("https://www.youtube.com/embed/tRMZ2Icpz6s?rel=0", videoController.ScrubYouTubeURL(url1));
            Assert.AreEqual("https://www.youtube.com/embed/Y-orMndwuSE?rel=0", videoController.ScrubYouTubeURL(url2));
            Assert.AreEqual("https://www.youtube.com/embed/tRMZ2Icpz6s?rel=0", videoController.ScrubYouTubeURL(url3));
        }
        [TestMethod]
        public void Video_CurrentChange()
        {
            Video newCurrentVideo = new Video { ID = 0, Title = "Test1", URL = "tRMZ2Icpz6s" };
            db.Videos.Add(newCurrentVideo);
            db.SaveChanges();
            Video addedVideo = (from vid in db.Videos
                               where vid.Title == newCurrentVideo.Title
                               select vid).FirstOrDefault();
            videoController.ChangeCurrentVideo(newCurrentVideo);
            Video currentVideo = db.CurrentVideo.Include("CurrentVideo").FirstOrDefault().CurrentVideo;
            Assert.AreEqual(currentVideo.Title, currentVideo.Title);
            Assert.AreEqual(currentVideo.URL, currentVideo.URL);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception), "Video not in Database")]
        public void Video_InvalidChange()
        {
            Video newCurrentVideo = new Video { ID = 0, Title = "Test1Invalid", URL = "tRMZ2Icpz6s" };
            videoController.ChangeCurrentVideo(newCurrentVideo);
        }

        [TestMethod]
        public void Video_CreateValid()
        {
            Video testVideo = new Video { ID = 0, Title = "TestCreate", URL = "https://www.youtube.com/watch?v=Y-orMndwuSE&ebc=ANyPxKoSFuYCSPtESFOr9_j-I_YrR1Ewk8Z9892MNtjkq5CwqNMuKpqWeofe0Y0urZGuufnUg_-rEmMygvqfv9dtiOoNhEmZiw" };
            videoController.Create(testVideo);
            testVideo = (from vid in db.Videos
                         where vid.Title == testVideo.Title
                         select vid).FirstOrDefault();
            Assert.IsNotNull(testVideo);
        }

        [TestMethod]
        public void Video_CreateInvalid()
        {
            Video testVideo = new Video { ID = 0, Title = "TestCreateInvalid" };
            videoController.Create(testVideo);
            testVideo = (from vid in db.Videos
                         where vid.Title == testVideo.Title
                         select vid).FirstOrDefault();
            Assert.IsNotNull(testVideo);
        }


        [TestMethod]
        public void Video_Delete()
        {
            Video newVideo = new Video { Title = "TestDeletedVideo", URL = "12345678" };
            db.Videos.Add(newVideo);
            db.SaveChanges();
            var testVideo = (from vid in db.Videos
                             where vid.Title == newVideo.Title
                             select vid).FirstOrDefault();
            var result = videoController.DeleteConfirmed(testVideo.ID) as RedirectToRouteResult;
            var deletedVideo = (from vid in db.Videos
                         where vid.Title == newVideo.Title
                         select vid).FirstOrDefault();
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNull(deletedVideo);
        }

        [TestMethod]
        public void Video_Index()
        {
            var result = videoController.Index() as ViewResult;
            var model = (VideoVM)result.Model;
            Assert.IsNotNull(model.AllVideos);
            Assert.IsNotNull(model.CurrentVideos);
        }

        [TestMethod]
        public void Video_SetCurrent()
        {
            Video newVideo = new Video { Title = "TestSetCurrent", URL = "12345678" };
            db.Videos.Add(newVideo);
            db.SaveChanges();
            var testVideo = (from vid in db.Videos
                             where vid.Title == newVideo.Title
                             select vid).FirstOrDefault();
            var result = videoController.SetCurrent(testVideo.ID) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual(testVideo.ID, db.CurrentVideo.FirstOrDefault().CurrentVideo.ID);
        }

    }
}
