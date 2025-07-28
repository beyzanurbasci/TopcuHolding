using System.ComponentModel.DataAnnotations;

public class ContactFormModel
{
	[Required(ErrorMessage = "Ad alanı zorunludur.")]
	[RegularExpression(@"^[A-Za-zÇçĞğİıÖöŞşÜü\s]{2,50}$", ErrorMessage = "Lütfen geçerli bir ad giriniz (sadece harf).")]
	public string Name { get; set; }

	[Required(ErrorMessage = "Email alanı zorunludur.")]
	[EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
	public string Email { get; set; }

	[Required(ErrorMessage = "Konu alanı zorunludur.")]
	[StringLength(100)]
	public string Subject { get; set; }

	[Required(ErrorMessage = "Mesaj alanı zorunludur.")]
	[StringLength(5000)]
	public string Message { get; set; }

	[Required(ErrorMessage = "Lütfen reCAPTCHA doğrulamasını tamamlayın.")]
	public string RecaptchaToken { get; set; }
}

