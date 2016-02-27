namespace Proj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        PostID = c.Int(nullable: false),
                        CommentHeader = c.String(nullable: false),
                        CommentAuthor = c.String(nullable: false),
                        CommentAuthorURL = c.String(nullable: false),
                        CommentDate = c.DateTime(nullable: false),
                        CommentText = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Post", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(nullable: false),
                        URLWebAddress = c.String(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                        Text = c.String(nullable: false),
                        ImageUrl = c.String(),
                        VideoUrl = c.String(),
                    })
                .PrimaryKey(t => t.PostID);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreID = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        latLocation = c.Double(nullable: false),
                        longLocation = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.StoreID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "PostID", "dbo.Post");
            DropIndex("dbo.Comment", new[] { "PostID" });
            DropTable("dbo.Stores");
            DropTable("dbo.Post");
            DropTable("dbo.Comment");
        }
    }
}
