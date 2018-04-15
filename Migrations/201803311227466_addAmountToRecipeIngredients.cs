namespace RecipeStorageAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAmountToRecipeIngredients : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RecipeIngredients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RecipeID = c.Int(nullable: false),
                        IngredientID = c.Int(nullable: false),
                        MeasureID = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Measures", t => t.MeasureID, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.RecipeID, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.IngredientID, cascadeDelete: true)
                .Index(t => t.RecipeID)
                .Index(t => t.IngredientID)
                .Index(t => t.MeasureID);
            
            CreateTable(
                "dbo.Measures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        PreparationTimeInMinutes = c.Int(nullable: false),
                        CookTimeInMinutes = c.Int(nullable: false),
                        RecipeCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.RecipeCategories", t => t.RecipeCategoryID, cascadeDelete: true)
                .Index(t => t.RecipeCategoryID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        URI = c.String(),
                        RecipeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Recipes", t => t.RecipeID, cascadeDelete: true)
                .Index(t => t.RecipeID);
            
            CreateTable(
                "dbo.RecipeCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RecipeSteps",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Instruction = c.String(),
                        Recipe_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Recipes", t => t.Recipe_ID)
                .Index(t => t.Recipe_ID);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        Recipe_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Recipes", t => t.Recipe_ID)
                .Index(t => t.Recipe_ID);
            
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Ratings", "Recipe_ID", "dbo.Recipes");
            DropForeignKey("dbo.RecipeIngredients", "IngredientID", "dbo.Ingredients");
            DropForeignKey("dbo.RecipeIngredients", "RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.RecipeSteps", "Recipe_ID", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "RecipeCategoryID", "dbo.RecipeCategories");
            DropForeignKey("dbo.Images", "RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.RecipeIngredients", "MeasureID", "dbo.Measures");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Ratings", new[] { "Recipe_ID" });
            DropIndex("dbo.RecipeSteps", new[] { "Recipe_ID" });
            DropIndex("dbo.Images", new[] { "RecipeID" });
            DropIndex("dbo.Recipes", new[] { "RecipeCategoryID" });
            DropIndex("dbo.RecipeIngredients", new[] { "MeasureID" });
            DropIndex("dbo.RecipeIngredients", new[] { "IngredientID" });
            DropIndex("dbo.RecipeIngredients", new[] { "RecipeID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Ratings");
            DropTable("dbo.RecipeSteps");
            DropTable("dbo.RecipeCategories");
            DropTable("dbo.Images");
            DropTable("dbo.Recipes");
            DropTable("dbo.Measures");
            DropTable("dbo.RecipeIngredients");
            DropTable("dbo.Ingredients");
        }
    }
}
