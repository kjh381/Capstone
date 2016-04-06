using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SARDT.Models;

namespace SARDT.Controllers
{
    public class VideosController : Controller
    {
        private SARDTContext db = new SARDTContext();

        // GET: /Videos/
        public ActionResult Index()
        {
            VideoVM indexVM = new VideoVM();
            indexVM.AllVideos = db.Videos.ToList();
            indexVM.CurrentVideos = db.CurrentVideo.Include("CurrentVideo").FirstOrDefault();
            return View(indexVM);
        }

        public ActionResult VideoView()
        {
            Video video = db.CurrentVideo.Include("CurrentVideo").FirstOrDefault().CurrentVideo;
            return View(video);
        }

        // GET: /Videos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Videos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Title,URL")] Video video)
        {
            if (ModelState.IsValid)
            {
                db.Videos.Add(video);
                string dirtyURL = video.URL;
                video.URL = ScrubYouTubeURL(dirtyURL);
                ChangeCurrentVideo(video);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(video);
        }

        public ActionResult SetCurrent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            ChangeCurrentVideo(video);
            return RedirectToAction("Index");
        }


        // GET: /Videos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: /Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Video video = db.Videos.Find(id);
            if (db.CurrentVideo.FirstOrDefault().CurrentVideo == video)
            {
                var currentVideo = db.CurrentVideo.FirstOrDefault();
                db.CurrentVideo.Remove(currentVideo);
            }
            db.Videos.Remove(video);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        private void ChangeCurrentVideo(Video video)
        {
            if (db.CurrentVideo.Count() > 0)
            {
                CurrentVideos oldCurrentVideo = db.CurrentVideo.FirstOrDefault();
                db.CurrentVideo.Remove(oldCurrentVideo);
            }
            CurrentVideos newCurrentVideo = new CurrentVideos();
            newCurrentVideo.CurrentVideo = video;
            db.CurrentVideo.Add(newCurrentVideo);
            db.SaveChanges();
        }

        private string ScrubYouTubeURL(string URL)
        {
            string videoKey = URL;
            if (URL.Length > 11 || URL.Contains("http") || URL.Contains("www"))
            {
                // example 1 - https://www.youtube.com/watch?v=tRMZ2Icpz6s
                // example 2 - https://www.youtube.com/watch?v=Y-orMndwuSE&ebc=ANyPxKoSFuYCSPtESFOr9_j-I_YrR1Ewk8Z9892MNtjkq5CwqNMuKpqWeofe0Y0urZGuufnUg_-rEmMygvqfv9dtiOoNhEmZiw
                string searchSub = "";
                int x = 0;
                int subLength = 3;
                while (x + subLength != (URL.Length - 1) && searchSub != "?v=")
                {
                    searchSub = URL.Substring(x, subLength);
                    if (searchSub != "?v=")
                        x++;
                }
                if (searchSub == "?v=")
                {
                    videoKey = URL.Substring(x + subLength, 11);
                }
            }
            return "https://www.youtube.com/embed/" + videoKey + "?rel=0";
        }


    }
}
