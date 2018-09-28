﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebLogin.Controllers
{
    public class UserController : Controller
    {
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.User user)
        {
            if (ModelState.IsValid)
            {
                if (this.IsValid(user.UserName, user.Password))
                {
                    if (user.UserName == "user1")
                    {
                        if(!Roles.IsUserInRole(user.UserName, "PAGE_1"))
                            Roles.AddUserToRole(user.UserName, "PAGE_1");
                    }
                    if (user.UserName == "user2")
                    {
                        if (!Roles.IsUserInRole(user.UserName, "PAGE_1"))
                            Roles.AddUserToRole(user.UserName, "PAGE_1");

                        if (!Roles.IsUserInRole(user.UserName, "PAGE_2"))
                            Roles.AddUserToRole(user.UserName, "PAGE_2");
                    }
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public bool IsValid(string userName, string password)
        {
            return true;
        }
    }
}