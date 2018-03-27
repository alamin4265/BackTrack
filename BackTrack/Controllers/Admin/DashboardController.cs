using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using BackTrack.Models;
using Newtonsoft.Json;

namespace BackTrack.Controllers
{
    public class DashboardController : Controller
    {
        private _ShowroomDB db = new _ShowroomDB();

        private class CategoryIdQuantity
        {
            public int CategoryId { get; set; }
            public double Quantity { get; set; }
        }
        private class DateQuantity
        {
            public string Date { get; set; }
            public double Quantity { get; set; }
        }
        public ActionResult Home()
        {
            List<CategoryIdQuantity> list = new List<CategoryIdQuantity>();
            var sale_product = from s in db.Sale
                               join p in db.Product on s.ProductId equals p.Id
                               select new { s, p };
            foreach (var sp in sale_product)
            {
                CategoryIdQuantity aCategoryIdQuantity = new CategoryIdQuantity();
                aCategoryIdQuantity.CategoryId = sp.p.CategoryId;
                aCategoryIdQuantity.Quantity = sp.s.Quantity;
                list.Add(aCategoryIdQuantity);
            }
            var cID = list.GroupBy(r => r.CategoryId).Select(i => new object[]
                {
                    i.Key,
                    i.Sum(x => x.Quantity)
                })
                .ToList();
            List<string> Category = new List<string>();
            List<double> quantity = new List<double>();
            for (int i = 0; i < cID.Count; i++)
            {
                int id = Convert.ToInt32(cID[i][0]);
                double q = (double)cID[i][1];
                Category.Add(db.Category.FirstOrDefault(c => c.Id == id).Name);
                quantity.Add(q);
            }
            ViewBag.category = Category;
            ViewBag.quantity = quantity;


            // Date Chart
            List<DateQuantity> list2 = new List<DateQuantity>();
            var voucher_sale_p = from s in db.Sale
                               join v in db.Voucher on s.VoucherId equals v.Id
                               join p in db.Product on s.ProductId equals p.Id
                               select new { s, v, p };
            foreach (var sv in voucher_sale_p)
            {
                DateQuantity aDateQuantity = new DateQuantity();
                aDateQuantity.Date = sv.v.DateTime.ToString();
                aDateQuantity.Quantity = sv.s.Quantity * sv.p.SellPrice;
                list2.Add(aDateQuantity);
            }
            var datechart = list2.GroupBy(v => v.Date).Select(i => new object[]
                    {
                    i.Key,
                    i.Sum(x => x.Quantity)
                    })
                .ToList();

            List<string> date = new List<string>();
            List<double> dquantity = new List<double>();
            for (int i = 0; i < datechart.Count; i++)
            {
                double q = (double)datechart[i][1];
                date.Add(datechart[i][0].ToString());
                dquantity.Add(q);
            }
            ViewBag.date = date;
            ViewBag.dquantity = dquantity;











            //List<Product> produclist = new List<Product>();
            //var sales = db.Sale.ToList();
            //foreach (var s in sales)
            //{
            //    List<Product> aProduct = new List<Product>();
            //    aProduct = db.Product.Where(p => p.Id == s.ProductId).ToList();



            //    List<Category> categoryList = new List<Category>();
            //    var products = db.Product.ToList();
            //    foreach (var p in products)
            //    {
            //        Category aCategory = new Category();
            //        aCategory.CategoryId = p.CategoryId;
            //        aCategory.Name = p.Category.Name;
            //        categoryList.Add(aCategory);
            //    }

            //categoryList.Add(aCategory);
            // }





            //var salep = db.Sale
            //    .Select(i => new { i.ProductId })
            //    .GroupBy(p => p.ProductId)
            //    .ToArray();

            //List<int> id = new List<int>();
            //List<string> category = new List<string>();
            //List<double> quantity = new List<double>();
            //foreach (var k in salep)
            //{
            //    id.Add(k.First().ProductId);
            //}
            //for (int i = 0; i < id.Count; i++)
            //{
            //    double q = 0;
            //    string c = "";
            //    int pid = id[i];
            //    var x = db.Sale.Where(e => e.ProductId == pid).ToList();
            //    foreach (var t in x)
            //    {
            //        c = t.Product.Category.Name;
            //        q += t.Quantity;
            //    }
            //category.Add(c);
            //quantity.Add(q);
            //}



            //ViewBag.DataPoints1
            return View();
        }
    }
}