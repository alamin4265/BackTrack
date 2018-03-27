using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BackTrack.Models;

namespace BackTrack.Controllers
{
    public class LoginController : Controller
    {
        private _ShowroomDB db = new _ShowroomDB();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var usr = db.User.FirstOrDefault(u => u.Email == loginModel.Email && u.Password == loginModel.Password);
                if (usr != null)
                {
                    if (usr.UserType.Name == "Admin")
                    {
                        Session["User_Id"] = usr.Id;
                        Session["User_Email"] = usr.Email;
                        Session["User_Name"] = usr.Name;
                        Session["Type"] = "Admin";
                        return RedirectToAction("Home","Dashboard");
                    }
                    else
                    {
                        Session["User_Id"] = usr.Id;
                        Session["User_Email"] = usr.Email;
                        Session["User_Name"] = usr.Name;
                        Session["Type"] = usr.UserType.Name;
                        return RedirectToAction("Create", "Sale");
                    }
                }
                else
                {
                    ViewBag.error = "Invalid Email or Password";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["User_Id"] = "";
            Session["User_Email"] = "";
            Session["User_Name"] = "";
            Session["Type"] = "";

            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();

            return RedirectToAction("Login", "Login");
        }
    }
}