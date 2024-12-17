using HemenBiletProje.Context;
using HemenBiletProje.Entities;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Collections.Generic;

namespace HemenBiletProje.Controllers
{
    public class RegisterController : Controller
    {
        TravelContext context = new TravelContext();

        // Kay�t formunu g�stermek i�in
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            try
            {
                // Kullan�c� ad� kontrol�
                var existingUser = context.Users.FirstOrDefault(x => x.UserName == user.UserName);
                if (existingUser != null)
                {
                    ViewBag.ErrorMessage = "Bu kullan�c� ad� zaten kay�tl�!";
                    return View();
                }

                // �ifreyi hash'le
                user.Password = HashPassword(user.Password);

                // Kullan�c�y� kaydet
                context.Users.Add(user);
                context.SaveChanges();

                ViewBag.SuccessMessage = "Kay�t ba�ar�yla tamamland�!";
                return RedirectToAction("Login", "Login");
            }
            catch (Exception ex)
            {
                // Hata meydana geldi�inde kullan�c�ya mesaj g�ster
                ViewBag.ErrorMessage = "Kay�t s�ras�nda bir hata olu�tu: " + ex.Message;
                return View();
            }
        }

        // �ifreyi SHA256 ile hash'lemek i�in
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}