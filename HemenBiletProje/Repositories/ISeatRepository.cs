using HemenBiletProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemenBiletProje.Repositories
{
    public interface ISeatRepository
    {
        List<Seat> GetAllSeats();
        Seat GetSeatById(int id);
        void AddSeat(Seat seat);
        void UpdateSeat(Seat seat);
        void DeleteSeat(int id);
    }

}

