namespace DbConection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AirportDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DBPassangers",
                c => new
                    {
                        passportNum = c.String(nullable: false, maxLength: 128),
                        planeNum = c.Int(nullable: false),
                        name = c.String(),
                        secondName = c.String(),
                        nationality = c.String(),
                        dateOfBirthday = c.DateTime(nullable: false),
                        sex = c.Int(nullable: false),
                        classF = c.Int(nullable: false),
                        price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.passportNum);
            
            CreateTable(
                "dbo.DBPlanes",
                c => new
                    {
                        planeNum = c.String(nullable: false, maxLength: 128),
                        timeIn = c.DateTime(nullable: false),
                        timeOut = c.DateTime(nullable: false),
                        city = c.String(),
                        airline = c.Int(nullable: false),
                        terminal = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                        gate = c.String(),
                        isPlaneInAirport = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.planeNum);
            
            CreateTable(
                "dbo.DBUsers",
                c => new
                    {
                        Login = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        Password = c.String(),
                        Name = c.String(),
                        LastName = c.String(),
                        IsEmploee = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Login);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DBUsers");
            DropTable("dbo.DBPlanes");
            DropTable("dbo.DBPassangers");
        }
    }
}
