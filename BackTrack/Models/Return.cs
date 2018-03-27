using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackTrack.Models
{
    [Table("Return")]
    public class Return
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Cell No Required")]
        public double CustomerCellNo { get; set; }
        public string DateTime { get; set; }

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Code Required")]
        [Remote("ProductCode", "IsExist", ErrorMessage = "Invalid Product")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "Quantity Required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Value must be numeric")]
        public double Quantity { get; set; }
        public int VoucherId { get; set; }
        public int UserId { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
        public virtual Voucher Voucher { get; set; }
    }
}