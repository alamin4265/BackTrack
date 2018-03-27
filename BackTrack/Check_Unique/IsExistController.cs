using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackTrack.Models;

namespace BackTrack.Check_Unique
{
    public class IsExistController : Controller
    {
        private _ShowroomDB db = new _ShowroomDB();

        public JsonResult CategoryName(string Name, int? Id,int? CategoryId)
        {
            var validate = db.Category.FirstOrDefault(x => x.Name == Name && x.Id != Id);
            if (validate != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult BrandName(string Name, int? Id)
        {
            var validate = db.Brand.FirstOrDefault(x => x.Name == Name && x.Id != Id);
            if (validate != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ColorName(string Name, int? Id)
        {
            var validate = db.Color.FirstOrDefault(x => x.Name == Name && x.Id != Id);
            if (validate != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult SizeName(string Name, int? Id)
        {
            var validate = db.Size.FirstOrDefault(x => x.Name == Name && x.Id != Id);
            if (validate != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ProductCode(string ProductCode, int? Id)
        {
            var validate = db.Product.FirstOrDefault(x => x.Code == ProductCode && x.Id != Id);
            if (validate == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}