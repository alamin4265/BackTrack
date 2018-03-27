using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.IO;

using System.Web;
using System.Web.Mvc;
using BackTrack.Models;
using iTextSharp.text;

namespace BackTrack.Controllers.Admin
{
    public class TopProductController : Controller
    {
        private _ShowroomDB db = new _ShowroomDB();
        //public ActionResult Product()
        //{
        //    return View();
        //}

        //[HttpPost]
        public ActionResult Product(Search search)
        {
            var sale_product = from s in db.Sale
                               join p in db.Product on s.ProductId equals p.Id
                               select new { s, p };
            var sale_product_group = sale_product.GroupBy(sp => sp.s.ProductId)
                .OrderByDescending(s => s.Sum(w => w.s.Quantity)).ToList().Take(10);
            List<Group> list = new List<Group>();
            foreach (var spg in sale_product_group)
            {
                Group aGroup = new Group();
                aGroup.ProductId = spg.First().s.ProductId;
                aGroup.Quantity = spg.Sum(s => s.s.Quantity);
                list.Add(aGroup);
            }
            ViewBag.TopProducts = list;



            if (search.Count == 0)
            {
                search.Count = 3;
            }
            var sale_product2 = from s in db.Sale
                join p in db.Product on s.ProductId equals p.Id
                select new { s, p };
            var sale_product_group2 = sale_product2.GroupBy(sp2 => sp2.s.ProductId).Where(x=>x.Sum(q=>q.s.Quantity)<=search.Count)
                .OrderByDescending(s => s.Sum(w => w.s.Quantity)).ToList().Take(10);
            List<Group> list2 = new List<Group>();
            foreach (var spg in sale_product_group2)
            {
                Group aGroup = new Group();
                aGroup.ProductId = spg.First().s.ProductId;
                aGroup.Quantity = spg.Sum(s => s.s.Quantity);
                list2.Add(aGroup);
            }
            ViewBag.TopProducts2 = list2;
            return View(search);
        }
    }
}