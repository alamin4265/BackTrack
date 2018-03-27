using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackTrack.Models
{
    [Table("Image")]
    public class Image
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}