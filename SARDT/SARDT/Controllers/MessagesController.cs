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
        SARDTContext db = new SARDTContext();
        UserManager<Member> userManager = new UserManager<Member>(
               new UserStore<Member>(new SARDTContext()));
        private EMailer messenger = new EMailer();

        // GET: /Messages/Index
        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        // GET: /Messages/StartConversation
        public ActionResult StartConversation()
        {
            ConversationsVM conversationsVM = new ConversationsVM();
            string userID = User.Identity.GetUserId();
            conversationsVM.Members = (from user in db.Users
                                       where user.Id != userID
                                       select user).OrderBy(item => item.Name).ToList();
            return View(conversationsVM);
        }

        [Authorize]
        // GET: /Messages/Messenger/5
        public ActionResult Messenger(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member currentMember = userManager.FindById(User.Identity.GetUserId());
            Member secondMember = db.Users.Find(id);
            if (secondMember == null || currentMember == null)
            {
                return HttpNotFound();
            }
            var conversation = (from c in db.Conversations
                                where (c.FirstMemberID == currentMember.Id && c.SecondMemberID == secondMember.Id) || (c.FirstMemberID == secondMember.Id && c.SecondMemberID == currentMember.Id)
                                      select c).FirstOrDefault();
            MessengerVM messengerVM = new MessengerVM();

            if (conversation == null)
            {
                Conversation newConv = new Conversation { FirstMemberID = currentMember.Id, SecondMemberID = secondMember.Id };
                db.Conversations.Add(newConv);
                db.SaveChanges();
                Conversation createdConv = (from c in db.Conversations
                                            where (c.FirstMemberID == currentMember.Id && c.SecondMemberID == secondMember.Id) || (c.FirstMemberID == secondMember.Id && c.SecondMemberID == currentMember.Id)
                                select c).FirstOrDefault();
                messengerVM.Conversation = createdConv;
            }
            else
            {
                conversation.UserMessages = (from m in db.UserMessages
                                             where m.ConversationID == conversation.ID
                                             select m).ToList();
                messengerVM.Conversation = conversation;
            }
            messengerVM.CurrentMember = currentMember;
            messengerVM.SecondMember = secondMember;
            return View(messengerVM);
        }


        [Authorize]
        // GET: /Messages/Messenger/5
        [HttpPost, ActionName("Messenger")]
        [ValidateAntiForgeryToken]
        public ActionResult MessengerSend(MessengerVM model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (model.CurrentMessage == null || model.CurrentMessage == "")
            {
                return View("Messenger", new { id = model.SecondMember.Id });
            }
            else
            {
                Message userMessage = new Message { AuthorID = User.Identity.GetUserId(), Body = model.CurrentMessage, Date = DateTime.Now, ConversationID = model.Conversation.ID, Unread = false };
                db.UserMessages.Add(userMessage);
                db.SaveChanges();
            }
            return RedirectToAction("Messenger", new { id = model.SecondMember.Id });
        }

        // POST: /Messages/SendMessage
        public ActionResult SendMessage(int conversationID, string secondMemberID, string messageBody)
        {
            if (secondMemberID == null || conversationID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (messageBody == null || messageBody == "")
            {
                return View("Messenger", new { id = secondMemberID });
            }
            else
            {
                Message userMessage = new Message { AuthorID = User.Identity.GetUserId(), Body = messageBody, Date = DateTime.Now, ConversationID = conversationID, Unread = false };
                db.UserMessages.Add(userMessage);
                db.SaveChanges();
            }
            return View("Messenger", new { id = secondMemberID });
        }

        [Authorize]
        // GET: /Messages/SystemSend
        public ActionResult SystemSend()
        {
            MessagesVM messagesVM = new MessagesVM();
            messagesVM.Members = db.Users.OrderBy(user => user.Name).ToList();
            foreach (Member member in messagesVM.Members)
            {
                messagesVM.SelectedMembers.Add(false);
            }
            messagesVM.Message = new SystemMessage();
            messagesVM.Message.From = userManager.FindById(User.Identity.GetUserId());
            return View(messagesVM);
        }

        // POST: /Messages/SystemSend
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SystemSend([Bind(Include = "Members,SelectedMembers,Message")] MessagesVM messagesVM)
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
            ResultVM resultVM = new ResultVM();
            if(messenger.SendMessageFromSystem(messagesVM.Message))
            {
                resultVM.ErrorOccurred = false;
                resultVM.Title = "Send Successful";
                resultVM.Message = "Your Notification has been sent successfully.";
                resultVM.RedirectViewName = "Member";
                resultVM.RedirectControllerName = "Home";
            }
            return View("ResultPage", resultVM);
        }

        [Authorize]
        // GET: /Messages/ResultPage
        public ActionResult ResultPage()
        {
            ResultVM resultVM = new ResultVM();
            resultVM.ErrorOccurred = false;
            resultVM.Title = "Redirect";
            resultVM.Message = "Click continue to return to the Member Page";
            resultVM.RedirectViewName = "Member";
            resultVM.RedirectControllerName = "Home";
            return View(resultVM);
        }

        // GET: /Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemMessage message = db.Messages.Find(id);
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
        public ActionResult Create([Bind(Include="ID,Subject,Body")] SystemMessage message)
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
            SystemMessage message = db.Messages.Find(id);
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
        public ActionResult Edit([Bind(Include="ID,Subject,Body")] SystemMessage message)
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
            SystemMessage message = db.Messages.Find(id);
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
            SystemMessage message = db.Messages.Find(id);
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
    }
}
