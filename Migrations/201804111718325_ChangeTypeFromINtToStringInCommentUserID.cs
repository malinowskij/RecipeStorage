namespace RecipeStorageAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeFromINtToStringInCommentUserID : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Comments", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Comments", "ApplicationUserID");
            RenameColumn(table: "dbo.Comments", name: "ApplicationUser_Id", newName: "ApplicationUserID");
            AlterColumn("dbo.Comments", "ApplicationUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comments", "ApplicationUserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "ApplicationUserID" });
            AlterColumn("dbo.Comments", "ApplicationUserID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Comments", name: "ApplicationUserID", newName: "ApplicationUser_Id");
            AddColumn("dbo.Comments", "ApplicationUserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "ApplicationUser_Id");
        }
    }
}
