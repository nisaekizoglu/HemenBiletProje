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
        private readonly TravelContext context;

        public RegisterController()
        {
            context = new TravelContext();
        }

        // Kayıt formunu göstermek için
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            try
            {
                // Kullanıcı adı kontrolü
                var existingUser = context.Users.FirstOrDefault(x => x.UserName == user.UserName);
                if (existingUser != null)
                {
                    ModelState.AddModelError("UserName", "Bu kullanıcı adı zaten kayıtlı!");
                    return View(user);
                }

                // Şifreyi hash'le
                user.Password = HashPassword(user.Password);

                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // Kullanıcıyı kaydet
                        context.Users.Add(user);
                        context.SaveChanges();
                        transaction.Commit();

                        TempData["SuccessMessage"] = "Kayıt başarıyla tamamlandı!";
                        return RedirectToAction("Login", "Login");
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Kayıt sırasında bir hata oluştu: " + ex.Message);
                return View(user);
            }
        }

        // Şifreyi SHA256 ile hash'lemek için
        private string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}