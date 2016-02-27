namespace Proj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Fans", "LoginDetails_Email");
            DropColumn("dbo.Fans", "LoginDetails_Password");
            DropColumn("dbo.Fans", "LoginDetails_ConfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fans", "LoginDetails_ConfirmPassword", c => c.String());
            AddColumn("dbo.Fans", "LoginDetails_Password", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Fans", "LoginDetails_Email", c => c.String(nullable: false));
        }
    }
}
