using HemenBiletProje.Context;
using HemenBiletProje.Entities;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace HemenBiletProje.Controllers
{
    public class LoginController : Controller
    {
        TravelContext context = new TravelContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUser user)
        {
            var existingUser = context.Users.FirstOrDefault(x => x.UserName == user.UserName);
            
            if (existingUser != null && VerifyPassword(user.Password, existingUser.Password))
            {
                // Oturum aç
                FormsAuthentication.SetAuthCookie(existingUser.UserName, false);
                Session["UserName"] = existingUser.UserName;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı!";
                return View();
            }
        }

        // Şifre doğrulama (Hash'lenmiş şifre ile karşılaştırma)
        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            var hashedInputPassword = HashPassword(inputPassword);
            return hashedInputPassword == storedHash;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
