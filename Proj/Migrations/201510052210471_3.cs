namespace Proj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fans", "LoginDetails_Email", c => c.String(nullable: false));
            AddColumn("dbo.Fans", "LoginDetails_Password", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Fans", "LoginDetails_ConfirmPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fans", "LoginDetails_ConfirmPassword");
            DropColumn("dbo.Fans", "LoginDetails_Password");
            DropColumn("dbo.Fans", "LoginDetails_Email");
        }
    }
}
