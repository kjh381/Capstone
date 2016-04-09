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
    public class WebImagesController : Controller
    {
        private SARDTContext db = new SARDTContext();

        // GET: /WebImages/
        public ActionResult Index()
        {
            List<WebImage> images = (from i in db.WebImages
                                     where i.InUse == true
                                     select i).ToList();
            return View(images);
        }

        // GET: /WebImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebImage webimage = db.WebImages.Find(id);
            if (webimage == null)
            {
                return HttpNotFound();
            }
            return View(webimage);
        }

        // GET: /WebImages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /WebImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="WebImageID,FileName,Caption,InUse")] WebImage webimage)
        {
            if (ModelState.IsValid)
            {
                db.WebImages.Add(webimage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(webimage);
        }

        // GET: /WebImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebImage webimage = db.WebImages.Find(id);
            if (webimage == null)
            {
                return HttpNotFound();
            }
            return View(webimage);
        }

        // POST: /WebImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="WebImageID,FileName,Caption,InUse")] WebImage webimage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webimage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(webimage);
        }

        // GET: /WebImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebImage webimage = db.WebImages.Find(id);
            if (webimage == null)
            {
                return HttpNotFound();
            }
            return View(webimage);
        }

        // POST: /WebImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WebImage webimage = db.WebImages.Find(id);
            db.WebImages.Remove(webimage);
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
    }
}
