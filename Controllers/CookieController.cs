//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;

//namespace TopcuHolding.Controllers
//{
//    [Route("cerezler")]
//    public class CookieController : Controller
//    {
//        [HttpGet("")]
//        public IActionResult Index()
//        {
//            // Kullanıcının mevcut çerez tercihlerini alıyoruz
//            var consent = Request.Cookies["cookieConsent"];
//            var analytics = Request.Cookies["cookieAnalytics"];
//            var ads = Request.Cookies["cookieAds"];
//            var performance = Request.Cookies["cookiePerformance"];

//            ViewBag.CookieConsent = consent;
//            ViewBag.Analytics = analytics == "true";
//            ViewBag.Ads = ads == "true";
//            ViewBag.Performance = performance == "true";

//            return View("Index");
//        }

//        [HttpPost("onay")]
//        [ValidateAntiForgeryToken]
//        public IActionResult HandleConsent(bool analytics = false, bool ads = false, bool performance = false)
//        {
//            var options = new CookieOptions
//            {
//                Expires = DateTimeOffset.UtcNow.AddDays(30),
//                HttpOnly = true,
//                Secure = Request.IsHttps,  // Sadece HTTPS ise secure koy
//                SameSite = SameSiteMode.Strict,
//                Path = "/"
//            };

//            // Zorunlu çerez olduğu için consent cookie true olarak set edilir
//            Response.Cookies.Append("cookieConsent", "true", options);

//            // İsteğe bağlı çerezleri tercihe göre set et
//            Response.Cookies.Append("cookieAnalytics", analytics ? "true" : "false", options);
//            Response.Cookies.Append("cookieAds", ads ? "true" : "false", options);
//            Response.Cookies.Append("cookiePerformance", performance ? "true" : "false", options);

//            TempData["Message"] = "Çerez tercihlerin kaydedildi.";

//            return RedirectToAction("Index");
//        }

//        [HttpGet("cerezpolitikasi")]
//        public IActionResult CookiePolicy()
//        {
//            return View("CookiePolicy");
//        }
//    }
//}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TopcuHolding.Controllers
{
    [Route("cookie")]
    public class CookieController : Controller
    {
        [HttpPost("set")]
        public IActionResult Set(bool consent = false, bool analytics = false, bool marketing = false)
        {
            var options = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1),
                HttpOnly = true,
                Secure = Request.IsHttps,
                SameSite = SameSiteMode.Strict
            };

            Response.Cookies.Append("CookieConsent", consent.ToString(), options);
            Response.Cookies.Append("AnalyticsConsent", analytics.ToString(), options);
            Response.Cookies.Append("MarketingConsent", marketing.ToString(), options);

            return Ok(new { message = "Çerez tercihleri başarıyla kaydedildi." });
        }

        [HttpGet("policy")]
        public IActionResult CookiePolicy()
        {
            return View("CookiePolicy"); // Views/Cookie/CookiePolicy.cshtml
        }
    }
}
