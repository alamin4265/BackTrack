using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackTrack.Models
{
    [Table("UserType")]
    public class UserType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }
}