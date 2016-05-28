using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SARDT.Models;
using System.Net.Mail;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SARDT.Controllers
{
    public class MessagesController : Controller
    {
        private SARDTContext db = new SARDTContext();
        UserManager<Member> userManager = new UserManager<Member>(
               new UserStore<Member>(new SARDTContext()));

        [Authorize]
        // GET: /Messages/
        public ActionResult Index()
        {
            MessagesVM messagesVM = new MessagesVM();
            messagesVM.Members = db.Users.OrderBy(user => user.Name).ToList();
            foreach (Member member in messagesVM.Members)
            {
                messagesVM.SelectedMembers.Add(false);
            }
            messagesVM.Message = new Message();
            messagesVM.Message.From = userManager.FindById(User.Identity.GetUserId());
            return View(messagesVM);
        }

        // POST: /Messages/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Members,SelectedMembers,Message")] MessagesVM messagesVM)
        {
            if (messagesVM == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            messagesVM.Members = db.Users.OrderBy(user => user.Name).ToList();
            for (int i = 0; i < messagesVM.Members.Count; i++ )
            {
                if (messagesVM.SelectedMembers[i])
                {
                    messagesVM.Message.To.Add(messagesVM.Members[i]);
                }
            }
            SendMessageFromUser(messagesVM.Message);
            return View();
        }

        // GET: /Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: /Messages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Subject,Body")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(message);
        }

        // GET: /Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: /Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Subject,Body")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        // GET: /Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: /Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
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

        private void SendMessageFromUser(Message message)
        {
            {
                /// Author, Md. Marufuzzaman
                /// Created,
                /// Local dependency, Microsoft .Net framework
                /// Description, Send an email using (SMTP).

                MailMessage mailMessage = new MailMessage();

                try
                {
                    mailMessage.From = new MailAddress("andreweskild@gmail.com");
                    foreach (Member member in message.To)
                    {
                        mailMessage.To.Add(new MailAddress(member.Email));
                    }
                    mailMessage.Subject = message.Subject;
                    mailMessage.Body = message.Body;

                    var gmailClient = new System.Net.Mail.SmtpClient {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        UseDefaultCredentials = false,
                        Credentials = new System.Net.NetworkCredential("andreweskild", "***************")
                    };

                    gmailClient.Send(mailMessage);
                } 
                catch (Exception ex)
                { 
                    throw ex; 
                }

                finally
                {
                    mailMessage = null;
                }
            }
        }
    }
}
