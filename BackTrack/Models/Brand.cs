using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackTrack.Models
{
    [Table("Brand")]
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        [Remote("BrandName","IsExist", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessage = "This Name Already Exist")]
        public string Name { get; set; }
        public string Origin { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}