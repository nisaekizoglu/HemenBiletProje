using System.ComponentModel.DataAnnotations;

namespace HemenBiletProje.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        public string FlightDate { get; set; }
        public string FlightStatus { get; set; }
        public string Airport { get; set; }
        public string Scheduled { get; set; }
    }
}
