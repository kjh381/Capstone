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

        // GET: /Default1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Default1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="WebTextID,Section,Body,LastChangedOn,LastChangeBy")] WebText webtext)
        {
            if (ModelState.IsValid)
            {
                db.WebTexts.Add(webtext);
                db.SaveChanges();
                return RedirectToAction("Index");
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
        public ActionResult Edit([Bind(Include="WebTextID,Section,Body,LastChangedOn,LastChangeBy")] WebText webtext)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webtext).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(webtext);
        }

        // GET: /Default1/Delete/5
        public ActionResult Delete(int? id)
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


        public ActionResult Test()
        {
            //WebText webtext = db.WebTexts.Find(id);
            WebText history = (from s in db.WebTexts
                               where s.Section == "History"
                               select s).FirstOrDefault();

            if (history == null)
            {
                return HttpNotFound();
            }
            return View(history);
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
