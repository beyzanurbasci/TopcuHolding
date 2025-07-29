using Microsoft.AspNetCore.Mvc;
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
                ViewBag.Success = true;
                ModelState.Clear();

            }
            else
            {
                return View(model); // validation hataları döner
            }

                return View();
        }
    }
}
