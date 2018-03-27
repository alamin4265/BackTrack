using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BackTrack.Models;

namespace BackTrack.Controllers.Admin
{
    public class BrandController : Controller
    {
        private _ShowroomDB db = new _ShowroomDB();

        // GET: Brand
        public ActionResult Index()
        {
            return View(db.Brand.ToList());
        }

        // GET: Brand/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brand.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // GET: Brand/Create
        public ActionResult Create()
        {
            ViewBag.TopBrandList = db.Brand.OrderByDescending(b => b.Id).Take(10).ToList();
            return View();
        }

        // POST: Brand/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Origin,Description")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Brand.Add(brand);
                db.SaveChanges();
                TempData["message"] = "New Brand Created Successfully";
                return RedirectToAction("Create");
            }
            ViewBag.TopBrandList = db.Brand.OrderByDescending(b => b.Id).Take(10).ToList();
            return View(brand);
        }

        // GET: Brand/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brand.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Origin,Description")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand).State = EntityState.Modified;
                db.SaveChanges();
                TempData["message"] = "Updated Successfully";
                return RedirectToAction("Edit");
            }
            return View(brand);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brand.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Brand.Remove(brand);
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
