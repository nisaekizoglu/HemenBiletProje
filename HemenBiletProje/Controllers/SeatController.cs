using HemenBiletProje.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HemenBiletProje.Controllers
{
    public class SeatController : Controller
    {
        private readonly SeatService _seatService;

        public SeatController(SeatService seatService)
        {
            _seatService = seatService;
        }

        public ActionResult Index()
        {
            var availableSeats = _seatService.GetAvailableSeats();
            return View(availableSeats);
        }

        public ActionResult SeatSelection()
        {
            var availableSeats = _seatService.GetAvailableSeats();
            return View(availableSeats);
        }

        [HttpPost]
        public ActionResult Reserve(int seatId)
        {
            _seatService.ReserveSeat(seatId);
            return RedirectToAction("Index");
        }
    }
}