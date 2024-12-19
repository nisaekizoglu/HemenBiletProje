using HemenBiletProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemenBiletProje.Services
{
    public interface ISeatService
    {
        List<Seat> GetAvailableSeats();
        void ReserveSeat(int seatId);
    }
}
