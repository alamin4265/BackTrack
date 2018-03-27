using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackTrack.Models
{
    [Table("Size")]
    public class Size
    {
        public int Id { get; set; }

        [Required]
        [Remote("SizeName", "IsExist", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessage = "This Size Already Exist")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}