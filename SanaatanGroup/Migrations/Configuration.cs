namespace SanaatanGroup.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<SanaatanGroup.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SanaatanGroup.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            context.Roles.AddOrUpdate(u => u.Name, new AppRole { Name = "Administrator" });
            context.Roles.AddOrUpdate(u => u.Name, new AppRole { Name = "Registered" });

            //    string name = "demo@sanaatangroup.com";
            //    string password = "password#123";
            //    var user = new ApplicationUser();
            //    user.UserName = name;
            //    user.BirthDate = System.DateTime.Today;
            //    user.LastLoginDate = System.DateTime.Today;
            //    user.LastActivityDate = System.DateTime.Today;
            //    user.Email = name;
            //    var adminresult = UserManager.Create(user, password);
            //    if (adminresult.Succeeded)
            //    {
            //        var result = UserManager.AddToRole(user.Id, "Administrator");
            //        var result1 = UserManager.AddToRole(user.Id, "Registered");
            //    }
            //    context.Users.AddOrUpdate(user);
            //
        }
    }
}
