using Microsoft.AspNetCore.Mvc;
using TopcuHolding.Route;
using TopcuHolding.Models;
using TopcuHolding.Route;
using TopcuHolding.Services;



namespace TopcuHolding.Controllers
{

    public class ContactController : Controller
    {
        private readonly GoogleRecaptchaService _recaptcha;
        private readonly EmailService _email;

        public ContactController(GoogleRecaptchaService recaptcha, EmailService email)
        {
            _recaptcha = recaptcha;
            _email = email;
        }

        [HttpGet]
        [Route(Routes.Contact.Index)]
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Index(ContactMessage model)
        {
            if (!await _recaptcha.VerifyAsync(model.RecaptchaToken))
                ModelState.AddModelError("", "reCAPTCHA doğrulaması başarısız.");

            if (ModelState.IsValid)
            {
                var mailBody = $"Ad: {model.Name}\nE-posta: {model.Email}\nMesaj:\n{model.Message}";
                await _email.SendEmailAsync("Yeni İletişim Mesajı", mailBody);

                model = new ContactMessage(); // Form temizlensin
                model.IsSuccess = true;       // 💥 Başarı flag’i set edildi

                TempData["FormMessage"] = "success";

                // ❗️Geldiği sayfaya geri dön
               
            }
            else
            {
                TempData["FormMessage"] = "error";
            }
            //return Ok();
            return Redirect(Request.Headers["Referer"].ToString());
            // return View(model); // Hatalıysa tekrar form döner
        }
    }
}
