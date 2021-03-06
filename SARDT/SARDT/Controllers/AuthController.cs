﻿using SARDT.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;





namespace SARDT.Controllers
{
    public class AuthController : Controller
    {
        private SARDTContext db = new SARDTContext();

        UserManager<Member> userManager = new UserManager<Member>(
               new UserStore<Member>(new SARDTContext()));

        [Authorize(Roles = "Moderator")]

        public ActionResult Index()
        {
            var roles = db.Roles.ToList();
            return View(roles);
        }

        [AllowAnonymous]
        //
        // GET: /Auth/Login/
        public ActionResult LogIn(string returnUrl)
        {
            var model = new LogInModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult LogIn(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = userManager.FindByEmail(model.Email);

            if (user != null)
            {
                if (userManager.CheckPassword(user, model.Password))
                {
                    var identity = userManager.CreateIdentity(
                        user, DefaultAuthenticationTypes.ApplicationCookie);

                    GetAuthenticationManager().SignIn(identity);

                    return Redirect(GetRedirectUrl(model.ReturnUrl));
                }
            }

            // user authentication failed
            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }

        //Yes this is intended behavior - we only want a moderator to be able to add a new member
        [Authorize(Roles = "Moderator")]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [Authorize(Roles = "Moderator")]
        [HttpPost]
        public ActionResult Register(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new Member
            {
                Email = model.Email,
                UserName = model.UserName
            };

            var result = userManager.Create(user, model.Password);

            if (result.Succeeded)
            {
                //SignIn(user); REMOVE - Moderator adds members
                return RedirectToAction("index", "calendar");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return View();
        }

        [AllowAnonymous]
        private void SignIn(Member user)
        {
            var identity = userManager.CreateIdentity(
                user, DefaultAuthenticationTypes.ApplicationCookie);

            GetAuthenticationManager().SignIn(identity);
        }

        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext();
            return ctx.Authentication;
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }

        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "home");
        }

        [Authorize(Roles = "Moderator, Member")]
        public ActionResult Profile()
        {
            var user = userManager.FindById(User.Identity.GetUserId());
            return View(user);
        }

        [Authorize(Roles = "Moderator, Member")]
        public ActionResult EditProfile()
        {
            var user = userManager.FindById(User.Identity.GetUserId());
            return View(user);
        }

        // POST: /Auth/EditProfile
        [Authorize(Roles = "Moderator, Member")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile([Bind(Include = "Id,Name,Email,UserName,Address,City,ZipCode,DOB,EmergencyContactName,EmergencyContactPhone")] Member member)
        {
            db.Entry(member).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Profile");
        }

        //*************************************  Roles   ***************************
        //GET: /Roles/Create
        [Authorize(Roles = "Moderator")]
        public ActionResult CreateRole()
        {
            return View();
        }

        //
        //POST: /Roles/Create
        //TODO: REMOVE - Unneeded for final version
        [Authorize(Roles = "Moderator")]
        [HttpPost]
        public ActionResult CreateRole(FormCollection collection)
        {
            try
            {
                db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = collection["RoleName"]
                });
                db.SaveChanges();
                ViewBag.ResultMessage = "Role created successfully!";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Delete Role from member?
        [Authorize(Roles = "Moderator")]
        public ActionResult Delete(string UserName, string RoleName)
        {
            Member user = db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            userManager.RemoveFromRole(user.Id, RoleName);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        //GET: /Roles/Edit
        [Authorize(Roles = "Moderator")]
        public ActionResult EditRole(string roleName)
        {
            var thisRole = db.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            return View(thisRole);
        }

        //
        //POST: /Roles/Edit
        [Authorize(Roles = "Moderator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRole(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role)
        {
            try
            {
                db.Entry(role).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Moderator")]
        public ActionResult ManageUserRoles()
        {
            var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
                new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();

            var Userlist = db.Users.OrderBy(r => r.UserName).ToList().Select(rr =>
                new SelectListItem { Value = rr.UserName.ToString(), Text = rr.UserName }).ToList();


            ViewBag.Roles = list;
            ViewBag.Users = Userlist;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Moderator")]
        public ActionResult RoleAddToUser(string UserName, string RoleName)
        {
            Member user = db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            userManager.AddToRole(user.Id, RoleName);
            
            var Userlist = db.Users.OrderBy(r => r.UserName).ToList().Select(rr =>
               new SelectListItem { Value = rr.UserName.ToString(), Text = rr.UserName }).ToList();

            ViewBag.ResultMessage = "Role added successfully!";

            var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            ViewBag.Users = Userlist;
            return View("ManageUserRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Moderator")]
        public ActionResult GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                Member user = db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                ViewBag.RolesForThisUser = userManager.GetRoles(user.Id);

                var Userlist = db.Users.OrderBy(r => r.UserName).ToList().Select(rr =>
               new SelectListItem { Value = rr.UserName.ToString(), Text = rr.UserName }).ToList();

                var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Roles = list;
                ViewBag.Users = Userlist;
            }
            return View("ManageUserRoles");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && userManager != null)
            {
                userManager.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}