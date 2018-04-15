namespace RecipeStorageAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratingRecipeID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "Recipe_ID", "dbo.Recipes");
            DropIndex("dbo.Ratings", new[] { "Recipe_ID" });
            RenameColumn(table: "dbo.Ratings", name: "Recipe_ID", newName: "RecipeID");
            AlterColumn("dbo.Ratings", "RecipeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Ratings", "RecipeID");
            AddForeignKey("dbo.Ratings", "RecipeID", "dbo.Recipes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "RecipeID", "dbo.Recipes");
            DropIndex("dbo.Ratings", new[] { "RecipeID" });
            AlterColumn("dbo.Ratings", "RecipeID", c => c.Int());
            RenameColumn(table: "dbo.Ratings", name: "RecipeID", newName: "Recipe_ID");
            CreateIndex("dbo.Ratings", "Recipe_ID");
            AddForeignKey("dbo.Ratings", "Recipe_ID", "dbo.Recipes", "ID");
        }
    }
}
