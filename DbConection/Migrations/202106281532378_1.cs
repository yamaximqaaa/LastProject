namespace DbConection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DBUsers", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DBUsers", "Id", c => c.Int(nullable: false));
        }
    }
}
