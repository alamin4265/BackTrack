using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackTrack.Models
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessage = "Value must be numeric")]
        public double BuyPrice { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessage = "Value must be numeric")]
        public double SellPrice { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Value must be numeric")]
        public double Quantity { get; set; }
        public string Warrenty { get; set; }
        public string Description { get; set; }
        public string DateTime { get; set; }

        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Size Size { get; set; }
        public virtual Color Color { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Return> Returns { get; set; }
    }
}