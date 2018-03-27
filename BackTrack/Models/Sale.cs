using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackTrack.Models
{
    [Table("Sale")]
    public class Sale
    {
        public int Id { get; set; }
        public double Quantity { get; set; }
        public string DateTime { get; set; }

        public int ProductId { get; set; }
        public int VoucherId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Voucher Voucher { get; set; }

    }
}