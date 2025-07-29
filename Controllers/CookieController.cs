using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace TopcuHolding.Controllers
{
    [Route("cerezler")]
    public class CookieController : Controller
    {
        public class CookieConsentModel
        {
            public bool Performance { get; set; }
            public bool Targeting { get; set; }
            public bool Functional { get; set; }
        }

        [HttpGet("cerezpolitikasi")]
        public IActionResult CookiePolicy()
        {
            return View(); // Views/Cookie/CookiePolicy.cshtml
        }

        [HttpPost("onay")]
        [ValidateAntiForgeryToken]
        public IActionResult SetConsent([FromBody] CookieConsentModel model)
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1),
                HttpOnly = true,
                Secure = Request.IsHttps,
                SameSite = SameSiteMode.Strict
            };

            Response.Cookies.Append("CookieConsent", "accepted", cookieOptions);
            Response.Cookies.Append("PerformanceCookies", model.Performance.ToString().ToLower(), cookieOptions);
            Response.Cookies.Append("TargetingCookies", model.Targeting.ToString().ToLower(), cookieOptions);
            Response.Cookies.Append("FunctionalCookies", model.Functional.ToString().ToLower(), cookieOptions);

            return Ok(new { success = true, message = "Çerez tercihleri kaydedildi." });
        }

        [HttpGet("kontrol")]
        public IActionResult CheckConsent()
        {
            var hasConsent = Request.Cookies.ContainsKey("CookieConsent");

            if (!hasConsent)
            {
                return Ok(new { hasConsent = false });
            }

            return Ok(new
            {
                hasConsent = true,
                performance = bool.Parse(Request.Cookies["PerformanceCookies"] ?? "false"),
                targeting = bool.Parse(Request.Cookies["TargetingCookies"] ?? "false"),
                functional = bool.Parse(Request.Cookies["FunctionalCookies"] ?? "false")
            });
        }
    }
}
