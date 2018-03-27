using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackTrack.Models
{
    [Table("LoginHistory")]
    public class LoginHistory
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public string DateTime { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}