using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BackTrack.Models;

namespace BackTrack.Controllers
{
    public class SizeController : Controller
    {
        private _ShowroomDB db = new _ShowroomDB();

        // GET: Size
        public ActionResult Index()
        {
            return View(db.Size.ToList());
        }

        // GET: Size/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Size size = db.Size.Find(id);
            if (size == null)
            {
                return HttpNotFound();
            }
            return View(size);
        }

        // GET: Size/Create
        public ActionResult Create()
        {
            ViewBag.TopSizeList = db.Size.OrderByDescending(c => c.Id).Take(10).ToList();
            return View();
        }

        // POST: Size/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Size size)
        {
            if (ModelState.IsValid)
            {
                db.Size.Add(size);
                db.SaveChanges();
                TempData["message"] = "New Size Created Successfully";
                return RedirectToAction("Create");
            }
            ViewBag.TopSizeList = db.Size.OrderByDescending(c => c.Id).Take(10).ToList();
            return View(size);
        }

        // GET: Size/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Size size = db.Size.Find(id);
            if (size == null)
            {
                return HttpNotFound();
            }
            return View(size);
        }

        // POST: Size/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Size size)
        {
            if (ModelState.IsValid)
            {
                db.Entry(size).State = EntityState.Modified;
                db.SaveChanges();
                TempData["message"] = "Updated Successfully";
                return RedirectToAction("Edit");
            }
            return View(size);
        }

        // GET: Size/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Size size = db.Size.Find(id);
            if (size == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Size.Remove(size);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
