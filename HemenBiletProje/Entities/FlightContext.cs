using System.Data.Entity;

namespace HemenBiletProje.Models
{
    // DbContext sınıfı
    public class FlightContext : DbContext
    {
        // Veritabanı bağlantı dizesi "DefaultConnection" üzerinden sağlanır
        public FlightContext() : base("name=FlightContext")
        {
        }

        // FlightInfo modelini DbSet olarak tanımlayın
        public DbSet<Flight> Flights { get; set; }
    }
}
