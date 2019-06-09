namespace Restaurant.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Restaurant.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Restaurant.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Restaurant.Models.ApplicationDbContext context)
        {
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userRole = rm.Create(new IdentityRole("User"));
            var adminRole = rm.Create(new IdentityRole("Admin"));
            var managRole = rm.Create(new IdentityRole("Manager"));
            var waiterRole = rm.Create(new IdentityRole("Waiter"));
            var CookRole = rm.Create(new IdentityRole("Cook"));
            var BarManRole = rm.Create(new IdentityRole("BarMan"));

            ApplicationUserManager usrManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var usr = new ApplicationUser()
            {
                FirstName = "Alex",
                LastName = "Lysha",
                PhoneNumber = "0872345765",
                Email = "sanyalysha97@gmail.com",
                UserName = "sanyalysha97@gmail.com"
            };
            usrManager.Create(usr, "sanyalysha61297");
            usrManager.AddToRole(usr.Id, "Admin");
        }
    }
}
