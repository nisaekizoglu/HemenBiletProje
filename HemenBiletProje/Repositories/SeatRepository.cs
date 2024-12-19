using HemenBiletProje.Context;
using HemenBiletProje.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HemenBiletProje.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly TravelContext _context;

        public SeatRepository(TravelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Seat> GetAllSeats()
        {
            return _context.Seats
                .AsNoTracking()
                .ToList();
        }

        public Seat GetSeatById(int id)
        {
            try
            {
                return _context.Seats
                    .AsNoTracking()
                    .FirstOrDefault(s => s.SeatId == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"ID'si {id} olan koltuk aranırken bir hata oluştu.", ex);
            }
        }

        public void AddSeat(Seat seat)
        {
            if (seat == null)
                throw new ArgumentNullException(nameof(seat));

            try
            {
                _context.Seats.Add(seat);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Koltuk eklenirken bir hata oluştu.", ex);
            }
        }

        public void UpdateSeat(Seat seat)
        {
            if (seat == null)
                throw new ArgumentNullException(nameof(seat));

            try
            {
                _context.Entry(seat).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Koltuk güncellenirken bir hata oluştu.", ex);
            }
        }

        public void DeleteSeat(int id)
        {
            var seat = _context.Seats.Find(id);
            if (seat == null)
                throw new ArgumentException($"ID'si {id} olan koltuk bulunamadı.");

            try
            {
                _context.Seats.Remove(seat);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Koltuk silinirken bir hata oluştu.", ex);
            }
        }
    }
}