using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackTrack.Models
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int? CategoryId { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}