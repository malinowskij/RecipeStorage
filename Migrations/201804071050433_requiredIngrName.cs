namespace RecipeStorageAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredIngrName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ingredients", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ingredients", "Name", c => c.String());
        }
    }
}
