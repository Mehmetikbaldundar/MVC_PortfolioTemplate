using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySiteProject.Models.Context;
using MySiteProject.Models.Entities;
using System.Security.Claims;

namespace MySiteProject.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        MySiteContext db = new MySiteContext();
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AdminTab admin)
        {
            var data = db.AdminTabs.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            if (data != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,admin.Username)
                };
                var userIdentity = new ClaimsIdentity(claims, "Security");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Admin");
            }
            return View();
        }


        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
