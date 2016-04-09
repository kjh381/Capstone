using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SARDT.Models;
using System.IO;

namespace SARDT.Controllers
{
    //[Authorize(Roles="Admin")]
    public class WebContentController : Controller
    {
        private SARDTContext db = new SARDTContext();

        // GET: /Default1/
        public ActionResult Index()
        {
            return View(db.WebTexts.ToList());
        }

        // GET: /Default1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebText webtext = db.WebTexts.Find(id);
            if (webtext == null)
            {
                return HttpNotFound();
            }
            return View(webtext);
        }

        // GET: /Default1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebText webtext = db.WebTexts.Find(id);
            if (webtext == null)
            {
                return HttpNotFound();
            }
            return View(webtext);
        }

        // POST: /Default1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="WebTextID,Section,Page,Body,LastChangedOn,LastChangeBy")] WebText webtext)
        {
            webtext.LastChangedOn = DateTime.Now;
            //TODO: Enable after identity is implemented.
            //webtext.LastChangeBy = User.Identity.Name;

            if (ModelState.IsValid)
            {
                db.Entry(webtext).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TextEditorIndex", new {pageName = webtext.Page});
            }
            return View(webtext);
        }

        // POST: /Default1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WebText webtext = db.WebTexts.Find(id);
            db.WebTexts.Remove(webtext);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult EditText()
        {
                return View();
        }

        public ActionResult TextEditorIndex(string pageName)
        {
            if (pageName == null)
                return RedirectToAction("EditText");
            else
            {
                List<WebText> textList = (from s in db.WebTexts
                                          where s.Page == pageName
                                          select s).ToList();

                if (textList == null)
                {
                    return HttpNotFound();
                }

                ViewBag.pageName = pageName;
                return View(textList);                
            }
        }

        public ActionResult WebImageIndex()
        {
            List<WebImage> images = (from i in db.WebImages
                                     where i.InUse == true
                                     select i).ToList();
            return View(images);
        }

        [HttpGet]
        public ActionResult ChangeImage()
        {
            List<WebImage> images = (from i in db.WebImages
                                     where i.InUse == false
                                     select i).ToList();
            return View(images);
        }

        [HttpPost]
        public ActionResult ChangeImage([Bind(Include = "WebImageID,FileName,Caption,InUse")] WebImage webimage)
        {
            return RedirectToAction("WebImageIndex");
        }

        public ActionResult DeleteImages(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebImage image = db.WebImages.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WebImage image = db.WebImages.Find(id);
            db.WebImages.Remove(image);
            db.SaveChanges();
            return RedirectToAction("WebImageIndex");
        }


        public ActionResult AddImage()
        {
            var image = new WebImage();
            return View(image);
        }

        [HttpPost]
        public ActionResult AddImage(HttpPostedFileBase file, [Bind(Include = "WebImageID, Caption")] WebImage image)
        {

            if (file != null && file.ContentLength > 0)
                try
                {                
                    //string unique = GenerateRandomText(10);
                    //string name = image.LocationID.ToString() + "/" + unique + file.FileName;
                    //string name = unique + file.FileName;
                    //string pathString = ("~/Images/"+image.LocationID);
                    //string path = Server.MapPath(pathString);
                    //Server.MapPath(pathString);
                    
                    //WAS WORKING
                    string path = Path.Combine(Server.MapPath("~/Images"),Path.GetFileName(file.FileName));
                    
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";

                    var img = new WebImage();
                    img.WebImageID = image.WebImageID;
                    img.InUse = false;
                    img.FileName = file.FileName;
                    img.Caption = image.Caption;

                    db.WebImages.Add(img);
                    db.SaveChanges();

                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            
            return RedirectToAction("AddImage");

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
