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
    public class ColorController : Controller
    {
        private _ShowroomDB db = new _ShowroomDB();

        // GET: Color
        public ActionResult Index()
        {
            return View(db.Color.ToList());
        }

        // GET: Color/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Color color = db.Color.Find(id);
            if (color == null)
            {
                return HttpNotFound();
            }
            return View(color);
        }

        // GET: Color/Create
        public ActionResult Create()
        {
            ViewBag.TopColorList = db.Color.OrderByDescending(c => c.Id).Take(10).ToList();
            return View();
        }

        // POST: Color/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Color color)
        {
            if (ModelState.IsValid)
            {
                db.Color.Add(color);
                db.SaveChanges();
                TempData["message"] = "New Color Created Successfully";
                return RedirectToAction("Create");
            }
            ViewBag.TopColorList = db.Color.OrderByDescending(c => c.Id).Take(10).ToList();
            return View(color);
        }

        // GET: Color/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Color color = db.Color.Find(id);
            if (color == null)
            {
                return HttpNotFound();
            }
            return View(color);
        }

        // POST: Color/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Color color)
        {
            if (ModelState.IsValid)
            {
                db.Entry(color).State = EntityState.Modified;
                db.SaveChanges();
                TempData["message"] = "Updated Successfully";
                return RedirectToAction("Edit");
            }
            return View(color);
        }

        // GET: Color/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Color color = db.Color.Find(id);
            if (color == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Color.Remove(color);
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
