namespace BackTrack.Migrations
{
    using BackTrack.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BackTrack.Models._ShowroomDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BackTrack.Models._ShowroomDB context)
        {
            _ShowroomDB db = new _ShowroomDB();

            //--   Fixed Category  --//
            db.Category.AddOrUpdate(new Category() { Id = 1, Name = "MEN'S Fashion", });
            db.Category.AddOrUpdate(new Category() { Id = 2, Name = "WOMEN'S Fashion", });
            db.Category.AddOrUpdate(new Category() { Id = 3, Name = "BABIES'S Fashion", });

            db.Category.AddOrUpdate(new Category() { Id = 4, Name = "SHIRT", CategoryId = 1 });
            db.Category.AddOrUpdate(new Category() { Id = 5, Name = "PANT", CategoryId = 1 });
            db.Category.AddOrUpdate(new Category() { Id = 6, Name = "PANJABI", CategoryId = 1 });
            db.Category.AddOrUpdate(new Category() { Id = 7, Name = "T-SHIRT", CategoryId = 1 });

            db.Category.AddOrUpdate(new Category() { Id = 8, Name = "FROCK", CategoryId = 2 });
            db.Category.AddOrUpdate(new Category() { Id = 9, Name = "SHARI", CategoryId = 2 });
            db.Category.AddOrUpdate(new Category() { Id = 10, Name = "3PEASE", CategoryId = 2 });
            db.Category.AddOrUpdate(new Category() { Id = 11, Name = "BORKA", CategoryId = 2 });

            db.Category.AddOrUpdate(new Category() { Id = 12, Name = "T-SHIRT", CategoryId = 3 });
            db.Category.AddOrUpdate(new Category() { Id = 13, Name = "PANT", CategoryId = 3 });

            //--   Fixed Brand  --//
            db.Brand.AddOrUpdate(new Brand() { Id = 1, Name = "Abroad" });
            db.Brand.AddOrUpdate(new Brand() { Id = 2, Name = "Local" });


            //--   Fixed Size  --//
            db.Size.AddOrUpdate(new Size() { Id = 1, Name = "S" });
            db.Size.AddOrUpdate(new Size() { Id = 2, Name = "M" });
            db.Size.AddOrUpdate(new Size() { Id = 3, Name = "L" });
            db.Size.AddOrUpdate(new Size() { Id = 4, Name = "XL" });

            //--   Fixed Color  --//
            db.Color.AddOrUpdate(new Color() { Id = 1, Name = "Red" });
            db.Color.AddOrUpdate(new Color() { Id = 2, Name = "Black" });
            db.Color.AddOrUpdate(new Color() { Id = 3, Name = "White" });


            //--   Fixed User_Type  --//
            db.UserType.AddOrUpdate(new UserType() { Id = 1, Name = "Admin" });
            db.UserType.AddOrUpdate(new UserType() { Id = 2, Name = "Manager" });
            db.UserType.AddOrUpdate(new UserType() { Id = 3, Name = "Employee" });

            //--   Fixed Users  --//
            db.User.AddOrUpdate(new User() { Id = 25, Name = "Abdullah Al Amin", Contact = "01910778228", Email = "admin@gmail.com", Password = "12345", Gender = 1, JoinDate = DateTime.Now.Date.ToString(), DOB = "1/08/1995", Address = "Road-09,Block-B,Section-06,Mirpur-02,Dhaka", NID = "132125464231", Image = "AdminImageTitle", UserTypeId = 1 });
            db.User.AddOrUpdate(new User() { Id = 26, Name = "Shohardo Bari", Contact = "01954542020", Email = "abcd@gmail.com", Password = "12345", Gender = 1, JoinDate = DateTime.Now.Date.ToString(), DOB = "1/08/1995", Address = "Road-32,Rupnogor,Mirpur-02,Dhaka", NID = "132125464231", Image = "AdminImageTitle", UserTypeId = 2 });
            db.User.AddOrUpdate(new User() { Id = 27, Name = "Fazlee Rabby", Contact = "01685800866", Email = "rabby@gmail.com", Password = "12345", Gender = 1, JoinDate = DateTime.Now.Date.ToString(), DOB = "1/08/1995", Address = "Road-02,ShialmariMor,Mirpur-02,Dhaka", NID = "132125464231", Image = "AdminImageTitle", UserTypeId = 3 });

            db.SaveChanges();
        }
    }
}
