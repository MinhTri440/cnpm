using MyPhamWeb.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyPhamWeb.Context;

namespace MyPhamWeb.Controllers
{
    public class AccountController : Controller
    {
        MyPhamEntities myphamWeb = new MyPhamEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Account _user)
        {
            if (ModelState.IsValid)
            {
                var check = myphamWeb.Accounts.FirstOrDefault(s => s.username == _user.username);

                if (check == null)
                {
                    myphamWeb.Configuration.ValidateOnSaveEnabled = false;
                    _user.type = "0";
                    myphamWeb.Accounts.Add(_user);
                    
                    myphamWeb.SaveChanges();
                    ViewBag.SuccessMessage = "Register success";
                    return RedirectToAction("Register");
                }

                else
                {
                    ViewBag.Error = "username already exists";
                    return View();
                }

            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(String username, string password)
        {
            if (ModelState.IsValid)
            {
                var check = myphamWeb.Accounts.FirstOrDefault(s => s.username == username && s.password == password);
                if (check != null)
                {
                    Session["UserName"] = check.username;
                    String roles = check.type;

                    // login with admin
                    if ( roles.Equals("1"))
                    {
                        Session["role"] = check.type;
                        return RedirectToAction("Index", "Home");

                    }
                    Session["role"] = check.type;


                    //add session of user

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }


            }
            return View("Login");
        }
        public ActionResult LogOut()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index");
        }
    }
}