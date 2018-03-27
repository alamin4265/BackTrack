using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using iTextSharp.text;
using iTextSharp.text.pdf;
using BackTrack.Models;

namespace BackTrack.Controllers
{
    public class SaleController : Controller
    {
        private _ShowroomDB db = new _ShowroomDB();
        // GET: Sale
        public ActionResult Create()
        {
            double total = 0;

            if (Session["CartList"] != null)
            {
                List<Cart> CartList = Session["CartList"] as List<Cart>;
                foreach (var x in CartList)
                {
                    total += x.SubTotal;
                }
                ViewBag.CartList = CartList;
            }

            ViewBag.ProductId = new SelectList(db.Product, "Id", "Name");
            ViewBag.VoucherId = new SelectList(db.Voucher, "Id", "CustomerNumber");
            ViewBag.Total = total;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cart sale)
        {
            List<Cart> CartList = new List<Cart>();
            try
            {
                sale.ProductId = db.Product.FirstOrDefault(p => p.Code == sale.ProductCode).Id;
            }
            catch
            {
                ModelState.AddModelError("ProductCode", "Invalid Code");
            }

            if (db.Product.FirstOrDefault(p => p.Code == sale.ProductCode).Quantity <= 0)
            {
                ModelState.AddModelError("Quantity", "Product is not Available");
            }
            if (ModelState.IsValid)
            {
                
                Cart cart = new Cart();

                if (Session["CartList"] != null)
                {
                    CartList = Session["CartList"] as List<Cart>;
                    foreach (var c in CartList)
                    {
                        if (c.ProductId == sale.ProductId)
                        {
                            var itemToRemove = CartList.SingleOrDefault(x => x.ProductId == Convert.ToInt32(sale.ProductId));
                            CartList.Remove(itemToRemove);
                            break;

                        }
                    }
                }

                
                cart.ProductId = sale.ProductId;
                cart.ProductName = db.Product.Find(sale.ProductId).Name;
                cart.Price = (double)db.Product.FirstOrDefault(c => c.Id == sale.ProductId).SellPrice;
                cart.Warrenty = sale.Warrenty;
                cart.Quantity = sale.Quantity;
                cart.SubTotal = cart.Price * sale.Quantity;
                cart.ProductCode = sale.ProductCode;
                CartList.Add(cart);
                Session["CartList"] = CartList;
                return RedirectToAction("Create");
            }

            ViewBag.ProductId = new SelectList(db.Product, "Id", "Name", sale.ProductId);
            return View(sale);
        }

        public ActionResult ItemDelete(int? Id)
        {
            List<Cart> CartList = new List<Cart>();
            CartList = Session["CartList"] as List<Cart>;
            var itemToRemove = CartList.SingleOrDefault(x => x.ProductId == Convert.ToInt32(Id));
            CartList.Remove(itemToRemove);
            Session["CartList"] = CartList;
            return RedirectToAction("Create");
        }


        
        [HttpPost]
        public ActionResult SendAndPrint(Cart cart)
        {
            List<Cart> CartList = new List<Cart>();
            CartList = Session["CartList"] as List<Cart>;

            if (CartList == null || CartList.Count <= 0)
            {
                return View("Create");
            }
            //Add Value into Voucher Table
            Voucher voucher = new Voucher();
            if (cart.CellNumber != null)
            {
                voucher.CustomerCellNo = cart.CellNumber;
            }
            voucher.UserId = int.Parse(Session["User_Id"].ToString());
            //voucher.Discount = Convert.ToDouble(cart.Discount);
            voucher.DateTime = DateTime.UtcNow.Date;
            db.Voucher.Add(voucher);
            if (db.SaveChanges() > 0)
            {
                //Add Value into Sale Table
                Sale aSale = new Sale();
                Product aProduct = new Product();

                foreach (var x in CartList)
                {                    
                    aSale.Quantity = x.Quantity;
                    aSale.ProductId = x.ProductId;
                    aSale.VoucherId = voucher.Id;
                    db.Sale.Add(aSale);


                    aProduct = db.Product.FirstOrDefault(p => p.Id == x.ProductId);
                    aProduct.Quantity -= x.Quantity;
                    db.Entry(aProduct).State = EntityState.Modified;

                    db.SaveChanges();
                }
                Session["CartList"] = null;

                //-----this is for pdf--------//

                int voucherI = voucher.Id;
                string paragraph = "Thank you for staying with us";
                GeneratePdf(voucherI, paragraph, CartList, cart.CellNumber);
            }
            return RedirectToAction("Create");

        }
        public void GeneratePdf(int voucherI, string paragraph, List<Cart> cartList, string cellN)
        {
            var document = new Document(PageSize.A4, 30, 30, 20, 20);
            PdfWriter.GetInstance(document, Response.OutputStream);
            document.Open();

            var voucher = new Paragraph(voucherI.ToString(), FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10));
            voucher.Alignment = Element.ALIGN_RIGHT;
            document.Add(voucher);

            var date = new Paragraph(DateTime.Now.ToString(), FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10));
            date.Alignment = Element.ALIGN_RIGHT;
            document.Add(date);

            var cellNumber = new Paragraph("Customer Cell No: " + cellN,FontFactory.GetFont(FontFactory.TIMES, 9));
            cellNumber.Alignment = Element.ALIGN_RIGHT;
            document.Add(cellNumber);

            var head = new Paragraph("BackTrack", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16));
            head.Alignment = Element.ALIGN_CENTER;
            document.Add(head);

            var Info = new Paragraph("#Mirpur Shopping Complex\nPolice Station Road,Mirpur-2,Dhaka-1216\nCell : 01910778228,01673106468", FontFactory.GetFont(FontFactory.TIMES, 10));
            Info.Alignment = Element.ALIGN_CENTER;
            document.Add(Info);


            //var newline = new Paragraph("\n");
            //document.Add(newline);


            //create pdf table
            var table = new PdfPTable(5) { TotalWidth = 316f };
            var widths = new float[] { 4f, 2f, 2f, 2f, 2f };
            table.SetWidths(widths);
            table.HorizontalAlignment = 0;
            table.SpacingBefore = 30f;
            table.SpacingAfter = 40f;
            table.DeleteBodyRows();


            double total = 0;

            table.AddCell("Product Name");
            table.AddCell("Code");
            table.AddCell("Price");
            table.AddCell("Quantity");
            table.AddCell("Sub Total");
            //table.AddCell("Warrenty");
            foreach (var c in cartList)
            {
                table.AddCell(c.ProductName);
                table.AddCell(c.ProductCode);
                table.AddCell(c.Price.ToString());
                table.AddCell(c.Quantity.ToString());
                table.AddCell(c.SubTotal.ToString());
                //table.AddCell(c.Warrenty);
                total += c.SubTotal;
            }
            var tot = new Paragraph("                  Total : " + total + " tk", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10));
            tot.Alignment = Element.ALIGN_BOTTOM;
            document.Add(tot);

            table.HorizontalAlignment = Element.ALIGN_CENTER;
            document.Add(table);
            document.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;  filename = Voucher.pdf");
            Response.End();
        }

        public ActionResult Clear()
        {
            Session["CartList"] = null;
            return RedirectToAction("Create");
        }
    }
}