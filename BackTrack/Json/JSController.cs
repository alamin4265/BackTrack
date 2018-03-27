using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackTrack.Models;

namespace BackTrack.Json
{
    public class JSController : Controller
    {
        private _ShowroomDB db = new _ShowroomDB();
        // GET: JS
        public JsonResult GetProducts(string code)
        {
            var product = db.Product.Where(p => p.Code.StartsWith(code));
            var jsonProduct = product.Select(s => new
            {
                Id = s.Id,
                Code = s.Code,
                
            });
            return Json(jsonProduct, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductInfoById(int Id)
        {
            var product = db.Product.FirstOrDefault(s => s.Id == Id);


            var jsonItem = new
            {
                Code = product.Code,
                Price = product.SellPrice,
                Quantity = product.Quantity,
                Warrenty = product.Warrenty,
                Name = product.Name


            };
            return Json(jsonItem, JsonRequestBehavior.AllowGet);
        }
    }
}