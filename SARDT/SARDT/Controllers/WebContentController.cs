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

        public ActionResult WebImageIndex(string message)
        {
            if (message == null)
            {
                message = "";
            }
            ViewBag.Message = message;

            List<WebImage> images = (from i in db.WebImages
                                     where i.InUse == true
                                     orderby i.Page, i.Location 
                                     select i).ToList();
            return View(images);
        }

        [HttpGet]
        public ActionResult ChangeImage(int id)
        {
            List<WebImage> images = (from i in db.WebImages
                                     where i.InUse == false
                                     select i).ToList();
            
            WebImage active = db.WebImages.Find(id);

            images.Insert(0, active);
            return View(images);
        }

        [HttpPost]
        public ActionResult ChangeActive(int oldID, int newID)
        {
            WebImage nowActive = db.WebImages.Find(newID);
            WebImage oldImage = db.WebImages.Find(oldID);

            nowActive.InUse = true;
            oldImage.InUse = false;
            nowActive.Page = oldImage.Page;
            oldImage.Page = "";

            nowActive.Location = oldImage.Location;
            oldImage.Location = null;
            
            db.SaveChanges();

            return RedirectToAction("ChangeImage", new {id = newID});
        }


        public ActionResult DeleteImage(int? id)
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

        [HttpPost, ActionName("DeleteImage")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteImageConfirmed(int id)
        {
            try
            {
                WebImage image = db.WebImages.Find(id);
                if (!image.InUse)
                {
                    string fullPath = Request.MapPath("~/Images/" + image.FileName);

                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }

                    db.WebImages.Remove(image);
                    db.SaveChanges();
                    string success = "Image successfully deleted.";
                    return RedirectToAction("WebImageIndex", new { message = success });
                }
                else {
                    string imageInUse = "Image is currently displayed on the website. Please change active image before deleting";
                    return RedirectToAction("WebImageIndex", new { message = imageInUse });                
                }
            }
            catch
            {
                string failure = "Delete image failed, Please try again.";
                return RedirectToAction("WebImageIndex", new { message = failure });
            }
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
                    string path = Path.Combine(Server.MapPath("~/Images"),Path.GetFileName(file.FileName));
                    
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";

                    var img = new WebImage();
                    img.WebImageID = image.WebImageID;
                    img.InUse = false;
                    img.FileName = file.FileName;
                    img.Caption = image.Caption;
                    img.Location = null;

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

        public ActionResult EditImage(int? id)
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
        public ActionResult EditImage([Bind(Include = "WebImageID,Caption,Location,FileName,Page,InUse")] WebImage webimage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webimage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("WebImageIndex");
            }
            return View(webimage);
        }

        public ActionResult UploadNewApplication(string message)
        {
            ViewBag.Message = message;
            return View();
        }

        [HttpPost]
        public ActionResult UploadNewApplication(HttpPostedFileBase file)
        {
            ViewBag.Message = "";
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Application"), Path.GetFileName(file.FileName));

                    if (System.IO.Path.GetExtension(file.FileName) == ".pdf")
                    {
                        Application app = new Application();

                        app = (from a in db.Applications
                               select a).FirstOrDefault();
                        
                        //Delete old application file
                        string fullPath = Request.MapPath("~/Application/" + app.FileName);

                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }

                        app.FileName = file.FileName;
                        
                        file.SaveAs(path);
                        ViewBag.Message = "File uploaded successfully";
                        db.SaveChanges();
                                                
                        return RedirectToAction("UploadNewApplication", new { message = ViewBag.Message });

                    }
                    ViewBag.Message = "File must be a PDF";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }

            return RedirectToAction("UploadNewApplication", new { message = ViewBag.Message });
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
