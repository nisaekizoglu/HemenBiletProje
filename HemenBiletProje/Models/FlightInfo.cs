

namespace HemenBiletProje.Models
{
    public class FlightInfo
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Airline { get; set; }
        public decimal Price { get; set; } = 0; //default değer
        public string FlightTime { get; set; }
    }
}