namespace HemenBiletProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FlightInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlightDate = c.DateTime(nullable: false),
                        FlightStatus = c.String(),
                        Airport = c.String(),
                        Scheduled = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FlightInfoes");
        }
    }
}
