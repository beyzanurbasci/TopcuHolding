//using Microsoft.AspNetCore.Mvc;
//using TopcuHolding.Route;



//namespace TopcuHolding.Controllers
//{  [Route(Routes.Contact.Index)]
//    public class ContactController : Controller
//    {

//        public IActionResult Index()
//        {
//            return View();
//        }
//    }
//}
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Newtonsoft.Json;

public class ContactController : Controller
{
    private readonly IWebHostEnvironment _env;
    private readonly IConfiguration _config;

    public ContactController(IWebHostEnvironment env, IConfiguration config)
    {
        _env = env;
        _config = config;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new ContactFormModel());
    }

    [HttpPost]
    public async Task<IActionResult> SubmitContactForm([FromBody] ContactFormModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var isCaptchaValid = await VerifyRecaptcha(model.RecaptchaToken);
        if (!isCaptchaValid)
            return BadRequest(new { error = "Geçersiz reCAPTCHA doğrulaması." });

        // 1. Veritabanı kaydı yapılacaksa buraya eklenebilir

        // 2. Email gönderimi
        var body = $@"
            <p><strong>Ad Soyad:</strong> {model.Name}</p>
            <p><strong>Email:</strong> {model.Email}</p>
            <p><strong>Konu:</strong> {model.Subject}</p>
            <p><strong>Mesaj:</strong><br />{model.Message}</p>";

        var mailMessage = new MailMessage
        {
            From = new MailAddress("your-email@example.com"),
            Subject = "İletişim Formu Mesajı",
            Body = body,
            IsBodyHtml = true
        };
        mailMessage.To.Add("info@topcuholding.com");

        using var smtp = new SmtpClient("smtp.example.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("your-email@example.com", "your-password"),
            EnableSsl = true
        };

        await smtp.SendMailAsync(mailMessage);

        return Ok(new { success = true, message = "Mesajınız başarıyla gönderildi." });
    }

    private async Task<bool> VerifyRecaptcha(string token)
    {
        var secret = _config["Recaptcha:SecretKey"];
        using var httpClient = new HttpClient();
        var response = await httpClient.PostAsync(
            $"https://www.google.com/recaptcha/api/siteverify?secret={secret}&response={token}",
            null);

        var json = await response.Content.ReadAsStringAsync();
        dynamic result = JsonConvert.DeserializeObject(json);
        return result.success == true && result.score >= 0.5;
    }
}
