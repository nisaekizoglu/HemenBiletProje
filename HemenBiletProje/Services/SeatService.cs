using HemenBiletProje.Models;
using HemenBiletProje.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HemenBiletProje.Services
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository _seatRepository;

        public SeatService(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public List<Seat> GetAvailableSeats()
        {
            return _seatRepository.GetAllSeats().Where(s => !s.IsBooked).ToList();
        }

        public void ReserveSeat(int seatId)
        {
            var seat = _seatRepository.GetSeatById(seatId);
            if (seat != null && !seat.IsBooked)
            {
                seat.IsBooked = true;
                _seatRepository.UpdateSeat(seat);
            }
        }
    }
}