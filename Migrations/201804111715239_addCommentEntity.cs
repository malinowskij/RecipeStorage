namespace RecipeStorageAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCommentEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        RecipeID = c.Int(nullable: false),
                        ApplicationUserID = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Recipes", t => t.RecipeID, cascadeDelete: true)
                .Index(t => t.RecipeID)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.Comments", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Comments", new[] { "RecipeID" });
            DropTable("dbo.Comments");
        }
    }
}
