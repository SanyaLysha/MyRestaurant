using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Restaurant.Entities;

namespace Restaurant.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual UserSalary UserSalary { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<BarOrder> BarOrders { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<KitchenOrder> KitchenOrders { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TableStatus> TableStatuses { get; set; }
        public DbSet<TableOrder> TableOrders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<DishRecipe> DishRecipes { get; set; }
        public DbSet<DrinkRecipe> DrinkRecipes { get; set; }
        public DbSet<ProductStorage> ProductStorage { get; set; }
        public DbSet<UserSalary> UserSalaries { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}