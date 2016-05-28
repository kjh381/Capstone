using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SARDT.Controllers;

namespace SARDT.Tests
{
    [TestClass]
    public class VideoTests
    {
        VideosController videoController = new VideosController();
        [TestMethod]
        public void TestScrubber()
        {
            string url1 = "https://www.youtube.com/watch?v=tRMZ2Icpz6s";
            string url2 = "https://www.youtube.com/watch?v=Y-orMndwuSE&ebc=ANyPxKoSFuYCSPtESFOr9_j-I_YrR1Ewk8Z9892MNtjkq5CwqNMuKpqWeofe0Y0urZGuufnUg_-rEmMygvqfv9dtiOoNhEmZiw";
            string url3 = "tRMZ2Icpz6s";

            Assert.AreEqual("https://www.youtube.com/embed/tRMZ2Icpz6s?rel=0", videoController.ScrubYouTubeURL(url1));
            Assert.AreEqual("https://www.youtube.com/embed/Y-orMndwuSE?rel=0", videoController.ScrubYouTubeURL(url2));
            Assert.AreEqual("https://www.youtube.com/embed/tRMZ2Icpz6s?rel=0", videoController.ScrubYouTubeURL(url3));
        }
    }
}
