using System.Collections.Generic;
using System.Web.Mvc;
using HemenBiletProje.Models;

namespace HemenBiletProje.Controllers
{
    public class FlightController : Controller
    {
        // Uçuş listeleme sayfası
        public ActionResult FlightList()
        {
            var flights = new List<FlightInfo>
    {
        new FlightInfo { From = "İstanbul", To = "New York", Price = 5000, FlightTime = "10:00 - 18:00", Airline = "Turkish Airlines" },
        new FlightInfo { From = "İstanbul", To = "Amsterdam", Price = 3500, FlightTime = "12:00 - 15:00", Airline = "Pegasus Airlines" },
        new FlightInfo { From = "Antalya", To = "Trabzon", Price = 2500, FlightTime = "14:00 - 16:00", Airline = "SunExpress" }
    };

            return View("FlightListPage",flights);
        }

        // Ödeme sayfasını döndüren Action
        public ActionResult Payment(string from, string to, decimal? price, string flightTime)
        {

            if (price == null)
            {
                // Eğer fiyat null ise kullanıcıyı uçuş listesine yönlendir
                return RedirectToAction("FlightList");
            }
            var flightInfo = new FlightInfo
            {
                From = from,
                To = to,
                Price = price.Value,
                FlightTime = flightTime
            };
            return View(flightInfo);
        }

        public ActionResult FlightSearchPage()
        {
            return View();
        }

        // Ödeme işlemini işleyen Action
        [HttpPost]
        public ActionResult ProcessPayment(string CardHolder, string CardNumber, string ExpiryDate, string CVV)
        {
            ViewBag.Message = "Ödeme işlemi başarıyla tamamlandı!";
            return View("Payment");
        }

        // İşlemi iptal etme
        public ActionResult CancelPayment()
        {
            return RedirectToAction("FlightList");
        }
    }
}
