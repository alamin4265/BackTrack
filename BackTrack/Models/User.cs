using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackTrack.Models
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Gender { get; set; }
        public string JoinDate { get; set; }
        public string Ip { get; set; }
        public string DOB { get; set; }
        public string Address { get; set; }
        public string NID { get; set; }
        public string Image { get; set; }

        public int UserTypeId { get; set; }

        public virtual UserType UserType { get; set; }
        public virtual ICollection<LoginHistory> LoginHistories { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
        public virtual ICollection<Return> Returns { get; set; }
    }
}