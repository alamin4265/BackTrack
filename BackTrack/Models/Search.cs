using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackTrack.Models
{
    public class Search
    {
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int Count { get; set; }
     
        [DataType(DataType.Date)]
        public DateTime? FromDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ToDate { set; get; }
    }
}