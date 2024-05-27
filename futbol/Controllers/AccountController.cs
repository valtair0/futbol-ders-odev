using futbol.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace futbol.Controllers
{
    public class AccountController : Controller
    {
        private readonly FutbolContext context;
        public AccountController()
        {
            context = new FutbolContext();
        }

        

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login([FromForm, Bind("Username", "Password")] User dataUser)
        {
            var user = context.Users.FirstOrDefault(x => x.Username == dataUser.Username && x.Password == dataUser.Password);
            if (user == null)
            {
                return View(dataUser);
            }

            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name,user.Username),
            };

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync(claimPrincipal);

            return RedirectToAction("Index", "Home");
        }

    }
}
