using System.ComponentModel.DataAnnotations;

namespace TopcuHolding.Models
{

    public class ContactMessage
    {
        
        public string Name { get; set; }

        public string Email { get; set; }

    
        public string Message { get; set; }

        // reCAPTCHA token backend'de kullanıldığı için validasyona gerek yok
        public string RecaptchaToken { get; set; }
    }

}
