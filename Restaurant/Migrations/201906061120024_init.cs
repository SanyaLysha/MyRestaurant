namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BarOrders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrderId = c.Long(nullable: false),
                        DrinkId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drinks", t => t.DrinkId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.DrinkId);
            
            CreateTable(
                "dbo.Drinks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TypeId = c.Int(nullable: false),
                        Name = c.String(),
                        Volume = c.Single(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DrinkTypes", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.DrinkRecipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DrinkId = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drinks", t => t.DrinkId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.DrinkId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Unit = c.String(),
                        Price = c.Single(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DishRecipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DishId = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dishes", t => t.DishId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.DishId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TypeId = c.Int(nullable: false),
                        Name = c.String(),
                        Weight = c.Single(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DishTypes", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.DishTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KitchenOrders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrderId = c.Long(nullable: false),
                        DishId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dishes", t => t.DishId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.DishId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Long(nullable: false),
                        Paid = c.Boolean(nullable: false),
                        TableId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tables", t => t.TableId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.TableId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TableStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TableStatus", t => t.TableStatusId, cascadeDelete: true)
                .Index(t => t.TableStatusId);
            
            CreateTable(
                "dbo.TableStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserSalaries",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        SalaryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Salaries", t => t.SalaryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.SalaryId);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Size = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductStorages",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.DrinkTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.TableOrders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TableId = c.Int(nullable: false),
                        UserId = c.Long(nullable: false),
                        Date = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tables", t => t.TableId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.TableId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TableOrders", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TableOrders", "TableId", "dbo.Tables");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.BarOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.BarOrders", "DrinkId", "dbo.Drinks");
            DropForeignKey("dbo.Drinks", "TypeId", "dbo.DrinkTypes");
            DropForeignKey("dbo.DrinkRecipes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductStorages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.DishRecipes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.KitchenOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserSalaries", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserSalaries", "SalaryId", "dbo.Salaries");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "TableId", "dbo.Tables");
            DropForeignKey("dbo.Tables", "TableStatusId", "dbo.TableStatus");
            DropForeignKey("dbo.KitchenOrders", "DishId", "dbo.Dishes");
            DropForeignKey("dbo.Dishes", "TypeId", "dbo.DishTypes");
            DropForeignKey("dbo.DishRecipes", "DishId", "dbo.Dishes");
            DropForeignKey("dbo.DrinkRecipes", "DrinkId", "dbo.Drinks");
            DropIndex("dbo.TableOrders", new[] { "User_Id" });
            DropIndex("dbo.TableOrders", new[] { "TableId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ProductStorages", new[] { "ProductId" });
            DropIndex("dbo.UserSalaries", new[] { "SalaryId" });
            DropIndex("dbo.UserSalaries", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Tables", new[] { "TableStatusId" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Orders", new[] { "TableId" });
            DropIndex("dbo.KitchenOrders", new[] { "DishId" });
            DropIndex("dbo.KitchenOrders", new[] { "OrderId" });
            DropIndex("dbo.Dishes", new[] { "TypeId" });
            DropIndex("dbo.DishRecipes", new[] { "ProductId" });
            DropIndex("dbo.DishRecipes", new[] { "DishId" });
            DropIndex("dbo.DrinkRecipes", new[] { "ProductId" });
            DropIndex("dbo.DrinkRecipes", new[] { "DrinkId" });
            DropIndex("dbo.Drinks", new[] { "TypeId" });
            DropIndex("dbo.BarOrders", new[] { "DrinkId" });
            DropIndex("dbo.BarOrders", new[] { "OrderId" });
            DropTable("dbo.TableOrders");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.DrinkTypes");
            DropTable("dbo.ProductStorages");
            DropTable("dbo.Salaries");
            DropTable("dbo.UserSalaries");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TableStatus");
            DropTable("dbo.Tables");
            DropTable("dbo.Orders");
            DropTable("dbo.KitchenOrders");
            DropTable("dbo.DishTypes");
            DropTable("dbo.Dishes");
            DropTable("dbo.DishRecipes");
            DropTable("dbo.Products");
            DropTable("dbo.DrinkRecipes");
            DropTable("dbo.Drinks");
            DropTable("dbo.BarOrders");
        }
    }
}
