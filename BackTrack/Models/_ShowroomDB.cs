using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace BackTrack.Models
{
    public class _ShowroomDB:DbContext
    {
        public _ShowroomDB() : base("ShowroomDB")
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Size> Size { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<LoginHistory> LoginHistory { get; set; }
        public DbSet<Voucher> Voucher { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<Return> Return { get; set; }

    }
}