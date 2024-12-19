using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HemenBiletProje.Models
{
    public class Seat
    {
        [Key]
        public int SeatId { get; set; } // Primary Key

        [Required]
        [StringLength(10)]
        public string SeatNumber { get; set; } // Koltuk Numarası

        [Required]
        public bool IsBooked { get; set; } // Rezerve Durumu
    }
}
