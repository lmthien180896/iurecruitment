namespace IUR.Data.Migrations
{
    using IUR.Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IUR.Data.IURDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IURDbContext context)
        {
            CreateUserSample(context);
        }

        private void CreateUserSample(IURDbContext context)
        {
            if (context.Users.Count() == 0)
            {
                List<User> listUserGroup = new List<User>()
            {
                new User() { Username = "tchc", HashedPassword = "337c6dd2ff9d49a0040f0c1c094b8711", Fullname = "Phòng tổ chức hành chính", Status = true },                
            };
                context.Users.AddRange(listUserGroup);
                context.SaveChanges();
            }
        }
    }
}
