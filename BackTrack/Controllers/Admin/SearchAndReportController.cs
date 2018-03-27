using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using BackTrack.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BackTrack.Controllers
{
    public class SearchAndReportController : Controller
    {
        private _ShowroomDB db = new _ShowroomDB();


        public ActionResult Index()
        {
            ViewBag.BrandId = new SelectList(db.Brand, "Id", "Name");
            ViewBag.ColorId = new SelectList(db.Color, "Id", "Name");
            ViewBag.SizeId = new SelectList(db.Size, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Index(Search search)
        {
            #region
            
            if (search.FromDate != null && search.ToDate != null)
            {
                Session["F"] = search.FromDate;
                Session["T"] = search.ToDate;

                if (search.CategoryId != 0 && search.BrandId != 0 && search.SizeId != 0 && search.ColorId != 0)
                {
                    ViewBag.Product = db.Sale.Include(s => s.Product.Brand).Include(s => s.Product.Category).Include(s => s.Product.Color).Include(s => s.Product.Size).Where(s => s.Product.CategoryId == search.CategoryId && s.Product.BrandId == search.BrandId && s.Product.SizeId == search.SizeId && s.Product.ColorId == search.ColorId && (s.Voucher.DateTime >= search.FromDate && s.Voucher.DateTime <= search.ToDate)).ToList();
                }
                else if (search.CategoryId == 0 && search.BrandId != 0 && search.SizeId != 0 && search.ColorId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.BrandId == search.BrandId && p.Product.SizeId == search.SizeId && p.Product.ColorId == search.ColorId && (p.Voucher.DateTime >= search.FromDate && p.Voucher.DateTime <= search.ToDate)).ToList();
                }
                else if (search.BrandId == 0 && search.CategoryId != 0 && search.SizeId != 0 && search.ColorId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.CategoryId == search.CategoryId && p.Product.SizeId == search.SizeId && p.Product.ColorId == search.ColorId && (p.Voucher.DateTime >= search.FromDate && p.Voucher.DateTime <= search.ToDate)).ToList();
                }
                else if (search.SizeId == 0 && search.CategoryId != 0 && search.BrandId != 0 && search.ColorId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.CategoryId == search.CategoryId && p.Product.BrandId == search.BrandId && p.Product.ColorId == search.ColorId && (p.Voucher.DateTime >= search.FromDate && p.Voucher.DateTime <= search.ToDate)).ToList();
                }
                else if (search.ColorId == 0 && search.CategoryId != 0 && search.BrandId != 0 && search.SizeId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.CategoryId == search.CategoryId && p.Product.BrandId == search.BrandId && p.Product.SizeId == search.SizeId && (p.Voucher.DateTime >= search.FromDate && p.Voucher.DateTime <= search.ToDate)).ToList();
                }

                else if (search.CategoryId == 0 && search.BrandId == 0 && search.SizeId != 0 && search.ColorId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.SizeId == search.SizeId && p.Product.ColorId == search.ColorId && (p.Voucher.DateTime >= search.FromDate && p.Voucher.DateTime <= search.ToDate)).ToList();
                }
                else if (search.CategoryId == 0 && search.SizeId == 0 && search.BrandId != 0 && search.ColorId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.BrandId == search.BrandId && p.Product.ColorId == search.ColorId && (p.Voucher.DateTime >= search.FromDate && p.Voucher.DateTime <= search.ToDate)).ToList();
                }
                else if (search.CategoryId == 0 && search.ColorId == 0 && search.BrandId != 0 && search.SizeId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.BrandId == search.BrandId && p.Product.SizeId == search.SizeId && (p.Voucher.DateTime >= search.FromDate && p.Voucher.DateTime <= search.ToDate)).ToList();
                }
                else if (search.BrandId == 0 && search.SizeId == 0 && search.CategoryId != 0 && search.ColorId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.CategoryId == search.CategoryId && p.Product.ColorId == search.ColorId && (p.Voucher.DateTime >= search.FromDate && p.Voucher.DateTime <= search.ToDate)).ToList();
                }
                else if (search.BrandId == 0 && search.ColorId == 0 && search.CategoryId != 0 && search.SizeId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.CategoryId == search.CategoryId && p.Product.SizeId == search.SizeId && (p.Voucher.DateTime >= search.FromDate && p.Voucher.DateTime <= search.ToDate)).ToList();
                }
                else if (search.SizeId == 0 && search.ColorId == 0 && search.CategoryId != 0 && search.BrandId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.CategoryId == search.CategoryId && p.Product.BrandId == search.BrandId && (p.Voucher.DateTime >= search.FromDate && p.Voucher.DateTime <= search.ToDate)).ToList();
                }

                else if (search.CategoryId == 0 && search.BrandId == 0 && search.SizeId == 0 && search.ColorId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.ColorId == search.ColorId && (p.Voucher.DateTime >= search.FromDate && p.Voucher.DateTime <= search.ToDate)).ToList();
                }
                else if (search.CategoryId == 0 && search.BrandId == 0 && search.ColorId == 0 && search.SizeId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.SizeId == search.SizeId && (p.Voucher.DateTime >= search.FromDate && p.Voucher.DateTime <= search.ToDate)).ToList();
                }
                else if (search.BrandId == 0 && search.SizeId == 0 && search.ColorId == 0 && search.CategoryId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.CategoryId == search.CategoryId && (p.Voucher.DateTime >= search.FromDate && p.Voucher.DateTime <= search.ToDate)).ToList();
                }
                else if (search.SizeId == 0 && search.ColorId == 0 && search.CategoryId == 0 && search.BrandId != 0)
                {
                    ViewBag.Product = db.Sale.Include(s => s.Product.Brand).Include(s => s.Product.Category).Include(s => s.Product.Color).Include(s => s.Product.Size).Where(s => s.Product.BrandId == search.BrandId && (s.Voucher.DateTime >= search.FromDate && s.Voucher.DateTime <= search.ToDate)).ToList();
                }
                else
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Voucher.DateTime >= search.FromDate && p.Voucher.DateTime <= search.ToDate).ToList();
                }

            }
            else
            {
                Session["F"] = " ";
                Session["T"] = " ";
                
                if (search.CategoryId != 0 && search.BrandId != 0 && search.SizeId != 0 && search.ColorId != 0)
                {
                    ViewBag.Product = db.Sale.Include(s => s.Product.Brand).Include(s => s.Product.Category).Include(s => s.Product.Color).Include(s => s.Product.Size).Where(s => s.Product.CategoryId == search.CategoryId && s.Product.BrandId == search.BrandId && s.Product.SizeId == search.SizeId && s.Product.ColorId == search.ColorId).ToList();
                }
                else if (search.CategoryId == 0 && search.BrandId != 0 && search.SizeId != 0 && search.ColorId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.BrandId == search.BrandId && p.Product.SizeId == search.SizeId && p.Product.ColorId == search.ColorId).ToList();
                }//
                else if (search.BrandId == 0 && search.CategoryId != 0 && search.SizeId != 0 && search.ColorId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.CategoryId == search.CategoryId && p.Product.SizeId == search.SizeId && p.Product.ColorId == search.ColorId).ToList();
                }
                else if (search.SizeId == 0 && search.CategoryId != 0 && search.BrandId != 0 && search.ColorId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.CategoryId == search.CategoryId && p.Product.BrandId == search.BrandId && p.Product.ColorId == search.ColorId).ToList();
                }
                else if (search.ColorId == 0 && search.CategoryId != 0 && search.BrandId != 0 && search.SizeId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.CategoryId == search.CategoryId && p.Product.BrandId == search.BrandId && p.Product.SizeId == search.SizeId).ToList();
                }

                else if (search.CategoryId == 0 && search.BrandId == 0 && search.SizeId != 0 && search.ColorId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.SizeId == search.SizeId && p.Product.ColorId == search.ColorId).ToList();
                }
                else if (search.CategoryId == 0 && search.SizeId == 0 && search.BrandId != 0 && search.ColorId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.BrandId == search.BrandId && p.Product.ColorId == search.ColorId).ToList();
                }
                else if (search.CategoryId == 0 && search.ColorId == 0 && search.BrandId != 0 && search.SizeId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.BrandId == search.BrandId && p.Product.SizeId == search.SizeId).ToList();
                }
                else if (search.BrandId == 0 && search.SizeId == 0 && search.CategoryId != 0 && search.ColorId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.CategoryId == search.CategoryId && p.Product.ColorId == search.ColorId).ToList();
                }
                else if (search.BrandId == 0 && search.ColorId == 0 && search.CategoryId != 0 && search.SizeId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.CategoryId == search.CategoryId && p.Product.SizeId == search.SizeId).ToList();
                }
                else if (search.SizeId == 0 && search.ColorId == 0 && search.CategoryId != 0 && search.BrandId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.CategoryId == search.CategoryId && p.Product.BrandId == search.BrandId).ToList();
                }

                else if (search.CategoryId == 0 && search.BrandId == 0 && search.SizeId == 0 && search.ColorId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.ColorId == search.ColorId).ToList();
                }
                else if (search.CategoryId == 0 && search.BrandId == 0 && search.ColorId == 0 && search.SizeId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.SizeId == search.SizeId).ToList();
                }
                else if (search.BrandId == 0 && search.SizeId == 0 && search.ColorId == 0 && search.CategoryId != 0)
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p => p.Product.CategoryId == search.CategoryId).ToList();
                }
                else if (search.SizeId == 0 && search.ColorId == 0 && search.CategoryId == 0 && search.BrandId != 0)
                {
                    ViewBag.Product = db.Sale.Include(s => s.Product.Brand).Include(s => s.Product.Category).Include(s => s.Product.Color).Include(s => s.Product.Size).Where(s => s.Product.BrandId == search.BrandId).ToList();
                }
                else
                {
                    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).ToList();
                }
            }

            #endregion


            //if (ViewBag.Product == null)
            //{
            //    ViewBag.Product = db.Sale.Include(p => p.Product.Brand).Include(p => p.Product.Category).Include(p => p.Product.Color).Include(p => p.Product.Size).Where(p=>p.Voucher.DateTime.AsDateTime() >= search.FromDate.AsDateTime() && p.Voucher.DateTime.AsDateTime() <= search.ToDate.AsDateTime()).ToList();
            //}
            ViewBag.CategoryId = search.CategoryId;
            if (search.CategoryId != 0)
            {
                ViewBag.CategoryName = db.Category.FirstOrDefault(c => c.Id == search.CategoryId).Name;
            }
            ViewBag.BrandId = new SelectList(db.Brand, "Id", "Name");
            ViewBag.ColorId = new SelectList(db.Color, "Id", "Name");
            ViewBag.SizeId = new SelectList(db.Size, "Id", "Name");
            return View();
        }
        

        public ActionResult PrintPdf()
        {
            List<Sale> sales = (List<Sale>)Session["SearchAndReportPdf"];

            ViewBag.BrandId = new SelectList(db.Brand, "Id", "Name");
            ViewBag.ColorId = new SelectList(db.Color, "Id", "Name");
            ViewBag.SizeId = new SelectList(db.Size, "Id", "Name");
            
            if (sales != null && sales.Count > 0)
            {
                GeneratePdf(sales, Session["F"].ToString(), Session["T"].ToString());
            }
            
            return View("Index");
        }

        public void GeneratePdf(List<Sale> sList,string fromDate, string toDate)
        {

            var document = new Document(PageSize.A4, 30, 30, 20, 20);
            PdfWriter.GetInstance(document, Response.OutputStream);
            document.Open();

            var date = new Paragraph(DateTime.Now.ToString(), FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10));
            date.Alignment = Element.ALIGN_RIGHT;
            document.Add(date);

            var head = new Paragraph("BackTrack", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16));
            head.Alignment = Element.ALIGN_CENTER;
            document.Add(head);

            var Info = new Paragraph("#Mirpur Shopping Complex\nPolice Station Road,Mirpur-2,Dhaka-1216\nCell : 01910778228,01673106468", FontFactory.GetFont(FontFactory.TIMES, 10));
            Info.Alignment = Element.ALIGN_CENTER;
            document.Add(Info);
            
            var cash = new Paragraph("\n\n Sale", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
            cash.Alignment = Element.ALIGN_CENTER;
            document.Add(cash);

            var pra = new Paragraph(fromDate + " - " + toDate, FontFactory.GetFont(FontFactory.TIMES, 10));
            pra.Alignment = Element.ALIGN_CENTER;
            document.Add(pra);


            //create pdf table
            var table = new PdfPTable(5) { TotalWidth = 416f };
            var widths = new float[] { 4f, 3f, 3f, 2f, 3f };
            table.SetWidths(widths);
            table.SpacingBefore = 20f;
            table.SpacingAfter = 20f;
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.DeleteBodyRows();


            double total = 0;
            double countProduct = 0;

            table.AddCell("Product Name");
            table.AddCell("Code");
            table.AddCell("Price");
            table.AddCell("Quantity");
            table.AddCell("Sub Total");
            //table.AddCell("Warrenty");
            foreach (var c in sList)
            {
                table.AddCell(c.Product.Name);
                table.AddCell(c.Product.Code);
                table.AddCell(c.Product.SellPrice.ToString());
                table.AddCell(c.Quantity.ToString());
                double sub = c.Product.SellPrice * c.Quantity;
                table.AddCell(sub.ToString());
                //table.AddCell(c.Warrenty);
                total += sub;
                countProduct += c.Quantity;
            }

            var count = new Paragraph("                    " + countProduct + " Products", FontFactory.GetFont(FontFactory.TIMES, 10));
            count.Alignment = Element.ALIGN_LEFT;
            document.Add(count);


            var tot = new Paragraph("                  Total : " + total + " tk", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10));
            tot.Alignment = Element.ALIGN_BOTTOM;
            document.Add(tot);


            document.Add(table);
            document.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;  filename =Voucher.pdf");
            Response.End();
        }
    }
}
