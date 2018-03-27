using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackTrack.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        [Remote("ProductCode", "IsExist", ErrorMessage = "Invalid Product")]
        public string ProductCode { get; set; }
        public double Price { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Value must be numeric")]
        public double Quantity { get; set; }
        public string Warrenty { get; set; }
        public string CellNumber { get; set; }
        public string Discount { get; set; }
        public double SubTotal { get; set; }
        public double Total { get; set; }
    }
}