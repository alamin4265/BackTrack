using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackTrack.Models;
using System.Data.Entity;

namespace BackTrack.Controllers
{
    public class VoucherController : Controller
    {
        _ShowroomDB db = new _ShowroomDB();
        public ActionResult Index()
        {
            if (Session["Type"] == null || Session["Type"].ToString() == "")
            {
                Session["dv"] = "Index";
                Session["dc"] = "Sale";
                return RedirectToAction("Login", "Login");
            }
            
            var vouchers = db.Voucher.Include(v => v.User);
            return View(vouchers.ToList());
        }
    }
}