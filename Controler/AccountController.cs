using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeMoney.DBases;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using MeMoney.UserIdentity;

namespace MeMoney.Controler
{
    public class AccountController : Controller
    {
        private readonly MyDbContext _context;  // replace with your DbContext

        static CheckUserIdentity userProperties;

        public static CheckUserIdentity UserProperties { get => userProperties; set => userProperties = value; }

        public AccountController(MyDbContext context)  // replace with your DbContext
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _context.MemAuthor.FirstOrDefaultAsync(u => u.Login == username && u.Password == password);  // replace with your User model
            userProperties = new CheckUserIdentity();
            if (user != null)
            {
                userProperties.IsMemAuthor = true;
                return await LoginForMemAuthor(user);
            }
            var companyUser = await _context.Company.FirstOrDefaultAsync(a => a.Login == username && a.Password == password);  // replace with your User model
            if (companyUser != null)
            {
                userProperties.IsMemAuthor = false;
                return await LoginForCompany(companyUser);
            }
            ViewData["Message"] = "Nieprawidłowy login lub hasło.";

            return RedirectToAction("Index", "Home");

        }

        private async Task<IActionResult> LoginForCompany(Company? companyUser)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, companyUser.Login)
                    // You can add more claims if required
                };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Index", "Home");
        }

        private async Task<IActionResult> LoginForMemAuthor(MemAuthor? user)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Login)
                    // You can add more claims if required
                };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
