document.addEventListener("DOMContentLoaded", function () {
    const form = document.getElementById("contactForm");
    const submitButton = form.querySelector('input[type="submit"]');

    // Önlem: Eğer daha önce event eklenmişse, tekrar eklenmesin
    if (form.hasAttribute("data-listener-attached")) return;
    form.setAttribute("data-listener-attached", "true");

    form.addEventListener("submit", function (e) {
        e.preventDefault(); // Sayfanın doğal submit'ini engeller
        submitButton.enabled = true;
        submitButton.blur(); // 👈 Bu satır görünmeyen "donukluk" sorununu çözer

        if (!validateForm()) return;

        const formData = new FormData(form);

        fetch(form.action, {
            method: "POST",
            body: formData
        })
            .then(response => {
                if (response.ok) {
                    alert("Mesajınız başarıyla gönderildi.");
                    form.reset();
                    grecaptcha.reset(); // varsa reCAPTCHA sıfırlansın
                } else {
                    alert("Mesaj gönderilirken bir hata oluştu.");
                }
                submitButton.blur(); // 👈 Bu satır görünmeyen "donukluk" sorununu çözer

                submitButton.enabled = true;

               
            })
            .catch(error => {
                console.error("Hata:", error);
                alert("Beklenmedik bir hata oluştu.");
                submitButton.enabled = true;
                submitButton.blur(); // 👈 Bu satır görünmeyen "donukluk" sorununu çözer

            });
    });

    function validateForm() {
        const name = document.getElementById("name").value.trim();
        const email = document.getElementById("email").value.trim();
        const message = document.getElementById("subject").value.trim();
        const token = document.getElementById("RecaptchaToken").value;

        const regexName = /^[a-zA-ZçğıöşüÇĞİÖŞÜ\s]{3,}$/;
        const regexEmail = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

        if (!regexName.test(name)) {
            alert("Lütfen geçerli bir isim giriniz.");
            return false;
        }

        if (!regexEmail.test(email)) {
            alert("Geçerli bir e-posta adresi giriniz.");
            return false;
        }

        if (message.length < 10) {
            alert("Mesajınız en az 10 karakter olmalıdır.");
            return false;
        }

        if (!token) {
            alert("Lütfen reCAPTCHA doğrulamasını tamamlayınız.");
            return false;
        }

        return true;
    }
});
