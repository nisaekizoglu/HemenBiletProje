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

        // Kayıt formunu göstermek için
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            try
            {
                // Kullanıcı adı kontrolü
                var existingUser = context.Users.FirstOrDefault(x => x.UserName == user.UserName);
                if (existingUser != null)
                {
                    ViewBag.ErrorMessage = "Bu kullanıcı adı zaten kayıtlı!";
                    return View();
                }

                // Şifreyi hash'le
                user.Password = HashPassword(user.Password);

                // Kullanıcıyı kaydet
                context.Users.Add(user);
                context.SaveChanges();

                ViewBag.SuccessMessage = "Kayıt başarıyla tamamlandı!";
                return RedirectToAction("Login", "Login");
            }
            catch (Exception ex)
            {
                // Hata meydana geldiğinde kullanıcıya mesaj göster
                ViewBag.ErrorMessage = "Kayıt sırasında bir hata oluştu: " + ex.Message;
                return View();
            }
        }

        // Şifreyi SHA256 ile hash'lemek için
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
