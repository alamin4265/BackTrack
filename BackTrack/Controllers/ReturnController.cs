using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackTrack.Models;
namespace BackTrack.Controllers
{
    public class ReturnController : Controller
    {
        _ShowroomDB db = new _ShowroomDB();
        public ActionResult Create()
        {
            ViewData["v"] = "0";
            if (Session["User_Id"] == null || Session["User_Id"].ToString() == "")
            {
                Session["dv"] = "Create";
                Session["dc"] = "Sale";
                return RedirectToAction("Login", "Login");
            }

            ViewBag.ProductId = new SelectList(db.Product, "Id", "Name");
            ViewBag.UserId = new SelectList(db.User, "Id", "Name");
            ViewBag.VoucherId = new SelectList(db.Voucher, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Return productReturn)
        {
            productReturn.DateTime = DateTime.Now.Date.ToShortDateString();
            productReturn.UserId = int.Parse(Session["User_Id"].ToString());
            if (ModelState.IsValid)
            {
                productReturn.ProductId=db.Product.FirstOrDefault(p => p.Code == productReturn.ProductCode).Id;
                db.Return.Add(productReturn);
                db.SaveChanges();

                Product aProduct = new Product();
                aProduct = db.Product.FirstOrDefault(p => p.Id == productReturn.ProductId);
                aProduct.Quantity += productReturn.Quantity;
                db.Entry(aProduct).State= EntityState.Modified;
                db.SaveChanges();

                Sale aSale = new Sale();
                aSale = db.Sale.FirstOrDefault(s => s.ProductId == productReturn.ProductId);
                aSale.Quantity -= productReturn.Quantity;
                db.Entry(aSale).State = EntityState.Modified;
                db.SaveChanges();
            }

            ViewBag.ProductId = new SelectList(db.Product, "Id", "Name", productReturn.ProductId);
            ViewBag.UserId = new SelectList(db.User, "Id", "Name", productReturn.UserId);
            ViewBag.VoucherId = new SelectList(db.Voucher, "Id", "CustomerNumber", productReturn.VoucherId);
            return View(productReturn);
        }

        public ActionResult GetAllSaleByVoucherId(Return pReturn)
        {
            ViewBag.v = pReturn.VoucherId;
            ViewBag.SellList = db.Sale.Where(s => s.VoucherId == pReturn.VoucherId).ToList();
            return View("Create");
        }
    }
}