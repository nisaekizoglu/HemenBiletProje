namespace HemenBiletProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airlines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Callsign = c.String(),
                        IATA = c.String(),
                        ICAO = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Airports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Timezone = c.String(),
                        IATA = c.String(),
                        ICAO = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartureAirportId = c.Int(nullable: false),
                        ArrivalAirportId = c.Int(nullable: false),
                        AirlineId = c.Int(nullable: false),
                        FlightNumber = c.String(),
                        DepartureTime = c.DateTime(nullable: false),
                        ArrivalTime = c.DateTime(nullable: false),
                        Terminal = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Airlines", t => t.AirlineId, cascadeDelete: true)
                .ForeignKey("dbo.Airports", t => t.ArrivalAirportId, cascadeDelete: true)
                .ForeignKey("dbo.Airports", t => t.DepartureAirportId, cascadeDelete: true)
                .Index(t => t.DepartureAirportId)
                .Index(t => t.ArrivalAirportId)
                .Index(t => t.AirlineId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Flights", "DepartureAirportId", "dbo.Airports");
            DropForeignKey("dbo.Flights", "ArrivalAirportId", "dbo.Airports");
            DropForeignKey("dbo.Flights", "AirlineId", "dbo.Airlines");
            DropIndex("dbo.Flights", new[] { "AirlineId" });
            DropIndex("dbo.Flights", new[] { "ArrivalAirportId" });
            DropIndex("dbo.Flights", new[] { "DepartureAirportId" });
            DropTable("dbo.Flights");
            DropTable("dbo.Airports");
            DropTable("dbo.Airlines");
        }
    }
}
