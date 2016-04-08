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
