using Microsoft.AspNetCore.Mvc;
using PFRCentr.App.MvcClient.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;

namespace PFRCentr.App.MvcClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secure()
        {
            return View();
        }

        [Authorize]
        public IActionResult Login()
        {
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Logout()
        {
            return SignOut(CookieAuthenticationDefaults.AuthenticationScheme,
                OpenIdConnectDefaults.AuthenticationScheme);
            // await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            // var prop = new AuthenticationProperties()
            // {
            //     RedirectUri = "https://localhost:5003"
            // };
            // await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme, prop);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}