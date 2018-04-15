namespace RecipeStorageAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNoToStep : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecipeSteps", "No", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RecipeSteps", "No");
        }
    }
}
