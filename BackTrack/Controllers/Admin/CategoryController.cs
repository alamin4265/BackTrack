using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using BackTrack.Models;

namespace BackTrack.Controllers
{
    public class CategoryController : Controller
    {
        private _ShowroomDB db = new _ShowroomDB();

        // GET: Category
        public ActionResult Index()
        {
            var category = db.Category.Include(c => c.ParentCategory);
            return View(category.ToList());
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Category, "Id", "Name");
            ViewBag.TopCategoryList = db.Category.OrderByDescending(c => c.Id).Take(10).ToList();
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CategoryId")] Category category)
        {
            if (db.Category.FirstOrDefault(c => c.Name == category.Name && c.CategoryId == category.CategoryId) !=
                null)
            {
                ModelState.AddModelError("Name", "This Name Already Exist IN This Category");
            }
            if (ModelState.IsValid)
            {
                db.Category.Add(category);
                db.SaveChanges();
                TempData["message"] = "New Categoery Created Successfully";
                return RedirectToAction("Create");
            }

            ViewBag.CategoryId = new SelectList(db.Category, "Id", "Name", category.CategoryId);
            ViewBag.TopCategoryList = db.Category.OrderByDescending(c => c.Id).Take(10).ToList();
            return View(category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Category, "Id", "Name", category.CategoryId);
            return View(category);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CategoryId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                TempData["message"] = "Updated Successfully";
                return RedirectToAction("Edit");
            }
            ViewBag.CategoryId = new SelectList(db.Category, "Id", "Name", category.CategoryId);
            return View(category);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Category.Remove(category);
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
