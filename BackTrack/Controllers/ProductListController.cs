using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackTrack.Models;


namespace BackTrack.Controllers
{
    public class ProductListController : Controller
    {
        _ShowroomDB db = new _ShowroomDB();
        public ActionResult Index()
        {            
            ViewBag.Product = db.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Size).ToList();
            return View();
        }
    }
}