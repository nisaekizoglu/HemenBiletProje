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

        // Kayýt formunu göstermek için
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            try
            {
                // Kullanýcý adý kontrolü
                var existingUser = context.Users.FirstOrDefault(x => x.UserName == user.UserName);
                if (existingUser != null)
                {
                    ViewBag.ErrorMessage = "Bu kullanýcý adý zaten kayýtlý!";
                    return View();
                }

                // Þifreyi hash'le
                user.Password = HashPassword(user.Password);

                // Kullanýcýyý kaydet
                context.Users.Add(user);
                context.SaveChanges();

                ViewBag.SuccessMessage = "Kayýt baþarýyla tamamlandý!";
                return RedirectToAction("Login", "Login");
            }
            catch (Exception ex)
            {
                // Hata meydana geldiðinde kullanýcýya mesaj göster
                ViewBag.ErrorMessage = "Kayýt sýrasýnda bir hata oluþtu: " + ex.Message;
                return View();
            }
        }

        // Þifreyi SHA256 ile hash'lemek için
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