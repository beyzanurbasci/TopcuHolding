using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TopcuHolding.Models;
using TopcuHolding.Route; // Route dosyan do�ru klas�rdeyse

namespace TopcuHolding.Controllers // NOT: Burada proje ad�n neyse onunla e�le�meli!
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route(Routes.Home.Index)]
        public IActionResult Index()
        {
            var cookieConsent = Request.Cookies["cookieConsent"];

            if (cookieConsent == "true")
            {
                ViewBag.AnalyticsEnabled = true;
            }
            else
            {
                ViewBag.AnalyticsEnabled = false;
            }

            return View();
        }
        [Route("cerezler-politikalar")]
        public IActionResult CookiePolicy()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Deneme()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
