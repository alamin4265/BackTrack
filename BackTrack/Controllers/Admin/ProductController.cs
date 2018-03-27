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
    public class ProductController : Controller
    {
        private _ShowroomDB db = new _ShowroomDB();

        // GET: Product
        public ActionResult Index(Search search)
        {
            ViewBag.BrandId = new SelectList(db.Brand, "Id", "Name");
            ViewBag.CategoryId = search.CategoryId;
            if (search.CategoryId != 0)
            {
                ViewBag.CategoryName = db.Category.FirstOrDefault(c => c.Id == search.CategoryId).Name;
            }
            ViewBag.ColorId = new SelectList(db.Color, "Id", "Name");
            ViewBag.SizeId = new SelectList(db.Size, "Id", "Name");

            if (search.CategoryId != 0 && search.BrandId != 0 && search.SizeId != 0 && search.ColorId != 0)
            {
                ViewBag.Product = db.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Size).Where(p => p.CategoryId == search.CategoryId && p.BrandId == search.BrandId && p.SizeId == search.SizeId && p.ColorId == search.ColorId).ToList();
            }
            else if (search.CategoryId == 0 && search.BrandId != 0 && search.SizeId != 0 && search.ColorId != 0)
            {
                ViewBag.Product = db.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Size).Where(p => p.BrandId == search.BrandId && p.SizeId == search.SizeId && p.ColorId == search.ColorId).ToList();
            }
            else if (search.BrandId == 0 && search.CategoryId != 0 && search.SizeId != 0 && search.ColorId != 0)
            {
                ViewBag.Product = db.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Size).Where(p => p.CategoryId == search.CategoryId && p.SizeId == search.SizeId && p.ColorId == search.ColorId).ToList();
            }
            else if (search.SizeId == 0 && search.CategoryId != 0 && search.BrandId != 0 && search.ColorId != 0)
            {
                ViewBag.Product = db.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Size).Where(p => p.CategoryId == search.CategoryId && p.BrandId == search.BrandId && p.ColorId == search.ColorId).ToList();
            }
            else if (search.ColorId == 0 && search.CategoryId != 0 && search.BrandId != 0 && search.SizeId != 0)
            {
                ViewBag.Product = db.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Size).Where(p => p.CategoryId == search.CategoryId && p.BrandId == search.BrandId && p.SizeId == search.SizeId).ToList();
            }

            else if (search.CategoryId == 0 && search.BrandId == 0 && search.SizeId != 0 && search.ColorId != 0)
            {
                ViewBag.Product = db.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Size).Where(p => p.SizeId == search.SizeId && p.ColorId == search.ColorId).ToList();
            }
            else if (search.CategoryId == 0 && search.SizeId == 0 && search.BrandId != 0 && search.ColorId != 0)
            {
                ViewBag.Product = db.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Size).Where(p => p.BrandId == search.BrandId && p.ColorId == search.ColorId).ToList();
            }
            else if (search.CategoryId == 0 && search.ColorId == 0 && search.BrandId != 0 && search.SizeId != 0)
            {
                ViewBag.Product = db.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Size).Where(p => p.BrandId == search.BrandId && p.SizeId == search.SizeId).ToList();
            }
            else if (search.BrandId == 0 && search.SizeId == 0 && search.CategoryId != 0 && search.ColorId != 0)
            {
                ViewBag.Product = db.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Size).Where(p => p.CategoryId == search.CategoryId && p.ColorId == search.ColorId).ToList();
            }
            else if (search.BrandId == 0 && search.ColorId == 0 && search.CategoryId != 0 && search.SizeId != 0)
            {
                ViewBag.Product = db.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Size).Where(p => p.CategoryId == search.CategoryId && p.SizeId == search.SizeId).ToList();
            }
            else if (search.SizeId == 0 && search.ColorId == 0 && search.CategoryId != 0 && search.BrandId != 0)
            {
                ViewBag.Product = db.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Size).Where(p => p.CategoryId == search.CategoryId && p.BrandId == search.BrandId).ToList();
            }

            else if (search.CategoryId == 0 && search.BrandId == 0 && search.SizeId == 0 && search.ColorId != 0)
            {
                ViewBag.Product = db.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Size).Where(p => p.ColorId == search.ColorId).ToList();
            }
            else if (search.CategoryId == 0 && search.BrandId == 0 && search.ColorId == 0 && search.SizeId != 0)
            {
                ViewBag.Product = db.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Size).Where(p => p.SizeId == search.SizeId).ToList();
            }
            else if (search.BrandId == 0 && search.SizeId == 0 && search.ColorId == 0 && search.CategoryId != 0)
            {
                ViewBag.Product = db.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Size).Where(p => p.CategoryId == search.CategoryId).ToList();
            }
            else if (search.SizeId == 0 && search.ColorId == 0 && search.CategoryId == 0 && search.BrandId != 0)
            {
                ViewBag.Product = db.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Size).Where(p => p.BrandId == search.BrandId).ToList();
            }
            else
            {
                ViewBag.Product = db.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Size).ToList();
            }

            if (ViewBag.Product == null)
            {
                ViewBag.Product = db.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Size).ToList();
            }
            return View();


            //    var product = db.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Size);
            //    return View(product.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brand, "Id", "Name");
            ViewBag.CategoryId = new SelectList(db.Category, "Id", "Name");
            ViewBag.ColorId = new SelectList(db.Color, "Id", "Name");
            ViewBag.SizeId = new SelectList(db.Size, "Id", "Name");
            ViewBag.TopProductList = db.Product.OrderByDescending(p => p.Id).Take(10).ToList();
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                product.DateTime = DateTime.Now.Date.ToString();
                db.Product.Add(product);
                db.SaveChanges();

                product.Code = product.Id.ToString() + product.CategoryId.ToString() + product.BrandId.ToString() + product.ColorId.ToString() + product.SizeId.ToString();

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                TempData["message"] = "New Product Created Successfully";
                if (Image != null)
                {
                    Image img = new Image();
                    img.ProductId = product.Id;
                    img.Title = System.IO.Path.GetFileName(Image.FileName);
                    db.Image.Add(img);
                    db.SaveChanges();
                    Image.SaveAs(Server.MapPath("../Uploads/ProductImages/" + img.Id + "_" + img.Title));
                }
                return RedirectToAction("Create");
            }

            ViewBag.BrandId = new SelectList(db.Brand, "Id", "Name", product.BrandId);
            ViewBag.CategoryId = new SelectList(db.Category, "Id", "Name", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Color, "Id", "Name", product.ColorId);
            ViewBag.SizeId = new SelectList(db.Size, "Id", "Name", product.SizeId);
            ViewBag.TopProductList = db.Product.OrderByDescending(p => p.Id).Take(10).ToList();
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brand, "Id", "Name", product.BrandId);
            ViewBag.CategoryId = new SelectList(db.Category, "Id", "Name", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Color, "Id", "Name", product.ColorId);
            ViewBag.SizeId = new SelectList(db.Size, "Id", "Name", product.SizeId);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Code,BuyPrice,SellPrice,Quantity,Warrenty,Description,DateTime,CategoryId,BrandId,SizeId,ColorId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                TempData["message"] = "Product Updated Successfully";
                return RedirectToAction("Edit");
            }
            ViewBag.BrandId = new SelectList(db.Brand, "Id", "Name", product.BrandId);
            ViewBag.CategoryId = new SelectList(db.Category, "Id", "Name", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Color, "Id", "Name", product.ColorId);
            ViewBag.SizeId = new SelectList(db.Size, "Id", "Name", product.SizeId);
            return View(product);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Product.Remove(product);
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
