using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackTrack.Models;

namespace BackTrack.Controllers.Admin
{
    public class ReturnedProductController : Controller
    {
        _ShowroomDB db = new _ShowroomDB();
        public ActionResult Index()
        {            
            return View(db.Return.ToList());
        }
    }
}