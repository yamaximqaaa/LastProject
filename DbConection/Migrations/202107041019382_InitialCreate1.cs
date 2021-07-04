namespace DbConection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DBPassangers", "planeNum", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DBPassangers", "planeNum", c => c.Int(nullable: false));
        }
    }
}
