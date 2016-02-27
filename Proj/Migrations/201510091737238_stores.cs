namespace Proj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stores : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "latLocation", c => c.Double(nullable: false));
            AddColumn("dbo.Stores", "longLocation", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stores", "longLocation");
            DropColumn("dbo.Stores", "latLocation");
        }
    }
}
