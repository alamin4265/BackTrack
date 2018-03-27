using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackTrack.Models
{
    [Table("Voucher")]
    public class Voucher
    {
        public int Id { get; set; }
        public string CustomerCellNo { get; set; }
        public double? Discount { get; set; }
        public DateTime? DateTime { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Return> Returns { get; set; }
    }
}