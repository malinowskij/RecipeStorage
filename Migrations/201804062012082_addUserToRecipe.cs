namespace RecipeStorageAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserToRecipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "ApplicationUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Recipes", "ApplicationUserID");
            AddForeignKey("dbo.Recipes", "ApplicationUserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Recipes", new[] { "ApplicationUserID" });
            DropColumn("dbo.Recipes", "ApplicationUserID");
        }
    }
}
