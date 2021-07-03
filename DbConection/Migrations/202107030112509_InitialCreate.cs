namespace DbConection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DBPlanes", "isPlaneInAirport");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DBPlanes", "isPlaneInAirport", c => c.Boolean(nullable: false));
        }
    }
}
