namespace RecipeStorageAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeSteps : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeSteps", "Recipe_ID", "dbo.Recipes");
            DropIndex("dbo.RecipeSteps", new[] { "Recipe_ID" });
            RenameColumn(table: "dbo.RecipeSteps", name: "Recipe_ID", newName: "RecipeID");
            AlterColumn("dbo.RecipeSteps", "RecipeID", c => c.Int(nullable: false));
            CreateIndex("dbo.RecipeSteps", "RecipeID");
            AddForeignKey("dbo.RecipeSteps", "RecipeID", "dbo.Recipes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeSteps", "RecipeID", "dbo.Recipes");
            DropIndex("dbo.RecipeSteps", new[] { "RecipeID" });
            AlterColumn("dbo.RecipeSteps", "RecipeID", c => c.Int());
            RenameColumn(table: "dbo.RecipeSteps", name: "RecipeID", newName: "Recipe_ID");
            CreateIndex("dbo.RecipeSteps", "Recipe_ID");
            AddForeignKey("dbo.RecipeSteps", "Recipe_ID", "dbo.Recipes", "ID");
        }
    }
}
