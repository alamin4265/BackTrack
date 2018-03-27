using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackTrack.Models
{
    [Table("Color")]
    public class Color
    {
        public int Id { get; set; }

        [Required]
        [Remote("ColorName","IsExist", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessage = "This Color Already Exist")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}