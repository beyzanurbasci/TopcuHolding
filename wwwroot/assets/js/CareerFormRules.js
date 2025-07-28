// Sayfa yüklendikinde bugünün tarihini ayarla
document.addEventListener('DOMContentLoaded', function () {
    const today = new Date();
    const formattedDate = today.toISOString().split('T')[0];

    // Doğum tarihi için maksimum bugünün tarihi
    document.getElementById('birthDate').max = formattedDate;

    // Başlangıç tarihi için minimum bugünün tarihi
    document.getElementById('startDate').min = formattedDate;

    // Mezuniyet yılı için maksimum değer
    document.getElementById('graduationYear').max = today.getFullYear();
});

// Telefon numarası maskeleme
document.getElementById('phone').addEventListener('input', function (e) {
    let value = e.target.value.replace(/\D/g, '');

    if (value.length > 11) {
        value = value.slice(0, 11);
    }

    if (value.length >= 4) {
        value = value.replace(/(\d{4})(\d{3})(\d{2})(\d{2})/, '$1 $2 $3 $4');
    } else if (value.length >= 7) {
        value = value.replace(/(\d{4})(\d{3})/, '$1 $2');
    } else if (value.length >= 4) {
        value = value.replace(/(\d{4})/, '$1');
    }

    e.target.value = value;
});

// Maaş alanları için maskeleme
function formatSalary(input) {
    input.addEventListener('input', function (e) {
        let value = e.target.value.replace(/\D/g, '');
        if (value) {
            value = parseInt(value).toLocaleString('tr-TR');
        }
        e.target.value = value;
    });
}

formatSalary(document.getElementById('expectedSalary'));
formatSalary(document.getElementById('currentSalary'));

// Uyruk seçimine göre kimlik alanını göster/gizle
document.getElementById('nationality').addEventListener('change', function () {
    const identitySection = document.getElementById('identitySection');
    const identityInput = document.getElementById('identity');
    const identityLabel = document.getElementById('identityLabel');

    if (this.value === 'tc') {
        identitySection.style.display = 'block';
        identityLabel.textContent = 'T.C. Kimlik No ';
        identityInput.placeholder = '11111111111';
        identityInput.maxLength = 11;
        identityInput.required = true;
    } else if (this.value === 'foreign') {
        identitySection.style.display = 'block';
        identityLabel.textContent = 'Pasaport/Kimlik No ';
        identityInput.placeholder = 'Pasaport veya kimlik numaranız';
        identityInput.maxLength = 20;
        identityInput.required = true;
    } else {
        identitySection.style.display = 'none';
        identityInput.required = false;
        identityInput.value = '';
    }
});

// T.C. Kimlik No maskeleme
document.getElementById('identity').addEventListener('input', function (e) {
    const nationality = document.getElementById('nationality').value;

    if (nationality === 'tc') {
        let value = e.target.value.replace(/\D/g, '');
        if (value.length > 11) {
            value = value.slice(0, 11);
        }
        e.target.value = value;
    }
});

// Doğum tarihi kontrolü
document.getElementById('birthDate').addEventListener('change', function (e) {
    const selectedDate = new Date(e.target.value);
    const today = new Date();

    if (selectedDate > today) {
        e.target.value = today.toISOString().split('T')[0];
        showAlert('Doğum tarihi bugünden sonra olamaz!', 'warning');
    }

    // Yaş kontrolü (minimum 16 yaş)
    const age = today.getFullYear() - selectedDate.getFullYear();
    const monthDiff = today.getMonth() - selectedDate.getMonth();

    if (age < 16 || (age === 16 && monthDiff < 0)) {
        showAlert('Minimum yaş sınırı 16\'dır!', 'warning');
        e.target.value = '';
    }
});

// CV dosya yükleme kontrolü
document.getElementById('cv').addEventListener('change', function (e) {
    const file = e.target.files[0];
    const fileName = document.getElementById('cvFileName');

    if (file) {
        // Dosya boyutu kontrolü (5MB)
        if (file.size > 5 * 1024 * 1024) {
            showAlert('Dosya boyutu 5MB\'dan büyük olamaz!', 'error');
            e.target.value = '';
            fileName.style.display = 'none';
            return;
        }

        // Dosya tipi kontrolü
        const allowedTypes = ['application/pdf', 'application/msword', 'application/vnd.openxmlformats-officedocument.wordprocessingml.document'];
        if (!allowedTypes.includes(file.type)) {
            showAlert('Sadece PDF, DOC ve DOCX dosyaları kabul edilir!', 'error');
            e.target.value = '';
            fileName.style.display = 'none';
            return;
        }

        fileName.innerHTML = `<i class="fas fa-file-check me-2"></i>${file.name} (${Math.round(file.size / 1024)} KB)`;
        fileName.style.display = 'block';
    } else {
        fileName.style.display = 'none';
    }
});

// Form validasyonu
function validateForm() {
    let isValid = true;
    const requiredFields = [
        { id: 'firstName', message: 'Ad alanı zorunludur!' },
        { id: 'lastName', message: 'Soyad alanı zorunludur!' },
        { id: 'email', message: 'E-posta alanı zorunludur!' },
        { id: 'phone', message: 'Telefon alanı zorunludur!' },
        { id: 'nationality', message: 'Uyruk seçimi zorunludur!' },
        { id: 'birthDate', message: 'Doğum tarihi zorunludur!' },
        { id: 'city', message: 'Şehir seçimi zorunludur!' },
        { id: 'applicationType', message: 'Başvuru türü seçimi zorunludur!' },
        { id: 'department', message: 'Departman seçimi zorunludur!' },
        { id: 'position', message: 'Pozisyon alanı zorunludur!' },
        { id: 'education', message: 'Eğitim seviyesi seçimi zorunludur!' },
        { id: 'experience', message: 'Deneyim seçimi zorunludur!' },
        { id: 'skills', message: 'Yetenekler alanı zorunludur!' },
        { id: 'cv', message: 'CV dosyası zorunludur!' },
        { id: 'consent', message: 'KVKK onayı zorunludur!' },
        { id: 'accuracy', message: 'Bilgilerin doğruluğu onayı zorunludur!' },
        { id: 'gender', message: 'Cinsiyet seçimi zorunludur!' }
    ];

    // Zorunlu alanları kontrol et
    requiredFields.forEach(field => {
        const element = document.getElementById(field.id);
        const errorElement = document.getElementById(field.id + 'Error');

        if (!element.value || (element.type === 'checkbox' && !element.checked)) {
            element.classList.add('is-invalid');
            if (errorElement) {
                errorElement.textContent = field.message;
            }
            isValid = false;
        } else {
            element.classList.remove('is-invalid');
            if (errorElement) {
                errorElement.textContent = '';
            }
        }
    });

    // Uyruk seçiliyse kimlik kontrolü
    const nationality = document.getElementById('nationality').value;
    const identity = document.getElementById('identity');
    if (nationality && !identity.value) {
        identity.classList.add('is-invalid');
        document.getElementById('identityError').textContent = nationality === 'tc' ? 'T.C. Kimlik No zorunludur!' : 'Kimlik No zorunludur!';
        isValid = false;
    }

    // E-posta formatı kontrolü
    const email = document.getElementById('email');
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (email.value && !emailRegex.test(email.value)) {
        email.classList.add('is-invalid');
        document.getElementById('emailError').textContent = 'Geçerli bir e-posta adresi giriniz!';
        isValid = false;
    }

    // Telefon numarası kontrolü
    const phone = document.getElementById('phone');
    const phoneValue = phone.value.replace(/\D/g, '');
    if (phoneValue && phoneValue.length !== 11) {
        phone.classList.add('is-invalid');
        document.getElementById('phoneError').textContent = 'Telefon numarası 11 haneli olmalıdır!';
        isValid = false;
    }

    // T.C. Kimlik No kontrolü
    if (nationality === 'tc' && identity.value) {
        const tcValue = identity.value.replace(/\D/g, '');
        if (tcValue.length !== 11 || !validateTCKN(tcValue)) {
            identity.classList.add('is-invalid');
            document.getElementById('identityError').textContent = 'Geçerli bir T.C. Kimlik No giriniz!';
            isValid = false;
        }
    }

    return isValid;
}

// T.C. Kimlik No algoritması
function validateTCKN(tckn) {
    if (tckn.length !== 11) return false;
    if (tckn[0] === '0') return false;
    if (tckn === '11111111111') return false;

    let sum1 = 0, sum2 = 0;
    for (let i = 0; i < 9; i += 2) {
        sum1 += parseInt(tckn[i]);
    }
    for (let i = 1; i < 8; i += 2) {
        sum2 += parseInt(tckn[i]);
    }

    const check1 = (sum1 * 7 - sum2) % 10;
    const check2 = (sum1 + sum2 + parseInt(tckn[9])) % 10;

    return check1 === parseInt(tckn[9]) && check2 === parseInt(tckn[10]);
}

// Alert gösterme fonksiyonu
function showAlert(message, type = 'info') {
    const alertDiv = document.createElement('div');
    alertDiv.className = `alert alert-${type === 'error' ? 'danger' : type} alert-dismissible fade show position-fixed`;
    alertDiv.style.cssText = 'top: 20px; right: 20px; z-index: 9999; min-width: 300px;';
    alertDiv.innerHTML = `
                <i class="fas fa-${type === 'error' ? 'exclamation-triangle' : type === 'warning' ? 'exclamation-circle' : 'info-circle'} me-2"></i>
                ${message}
                <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
            `;
    document.body.appendChild(alertDiv);

    setTimeout(() => {
        if (alertDiv && alertDiv.parentNode) {
            alertDiv.remove();
        }
    }, 5000);
}

// Form gönderimi
document.getElementById('applicationForm').addEventListener('submit', function (e) {
    e.preventDefault();

    if (!validateForm()) {
        showAlert('Lütfen zorunlu alanları doldurunuz ve hataları düzeltiniz!', 'error');
        return;
    }

    // Loading durumu
    const submitBtn = e.target.querySelector('button[type="submit"]');
    const originalText = submitBtn.innerHTML;
    submitBtn.innerHTML = '<i class="fas fa-spinner fa-spin me-2"></i>Gönderiliyor...';
    submitBtn.disabled = true;

    // Simüle edilmiş gönderim
    setTimeout(() => {
        // Başarı modalını göster
        const referenceNumber = 'BA' + Date.now().toString().slice(-6);
        document.getElementById('referenceNumber').textContent = referenceNumber;

        const modal = new bootstrap.Modal(document.getElementById('successModal'));
        modal.show();

        // Formu sıfırla
        e.target.reset();
        document.getElementById('cvFileName').style.display = 'none';
        document.getElementById('identitySection').style.display = 'none';

        // Butonu eski haline getir
        submitBtn.innerHTML = originalText;
        submitBtn.disabled = false;

        // Tüm validation classlarını kaldır
        document.querySelectorAll('.is-invalid').forEach(el => {
            el.classList.remove('is-invalid');
        });

    }, 2000);
});

// Real-time validation
document.querySelectorAll('input, select, textarea').forEach(element => {
    element.addEventListener('blur', function () {
        if (this.hasAttribute('required') && !this.value) {
            this.classList.add('is-invalid');
        } else {
            this.classList.remove('is-invalid');
        }
    });

    element.addEventListener('input', function () {
        if (this.classList.contains('is-invalid') && this.value) {
            this.classList.remove('is-invalid');
        }
    });
});

// Sadece harf kabul eden alanlar
//function onlyLetters(input) {
//    input.addEventListener('input', function (e) {
//        e.target.value = e.target.value.replace(/[^a-zA-ZçÇğĞıİöÖşŞüÜ\s]/g, '');
//    });
//}

//onlyLetters(document.getElementById('firstName'));
//onlyLetters(document.getElementById('lastName'));
function onlyLetters(input) {
    input.addEventListener('input', function (e) {
        e.target.value = e.target.value.replace(/[^a-zA-ZçÇğĞıİöÖşŞüÜ\s]/g, '');
    });
}

// İlk ad ve soyad için
onlyLetters(document.getElementById('firstName'));
onlyLetters(document.getElementById('lastName'));

// Tüm iş tecrübesi kutularındaki "Kurum Adı" ve "Pozisyon" alanları için
document.querySelectorAll('#workExperienceContainer input').forEach(input => {
    const placeholder = input.getAttribute('placeholder');
    if (placeholder === 'Şirket/Kurum adı' || placeholder === 'İş unvanı') {
        onlyLetters(input);
    }
});




// Portfolio link validasyonu
document.getElementById('portfolio').addEventListener('blur', function () {
    const url = this.value;
    if (url && !url.match(/^https?:\/\/.+/)) {
        this.value = 'https://' + url;
    }
});

// Pozisyon alanını büyük harfe çevir
document.getElementById('position').addEventListener('blur', function () {
    this.value = this.value.toLowerCase().replace(/\b\w/g, l => l.toUpperCase());
});

// Şehir "Diğer" seçildiğinde
document.getElementById('city').addEventListener('change', function () {
    if (this.value === 'other') {
        const customCity = prompt('Lütfen şehrinizi yazınız:');
        if (customCity) {
            const option = document.createElement('option');
            option.value = customCity.toLowerCase();
            option.textContent = customCity;
            option.selected = true;
            this.appendChild(option);
        }
    }
});

// Departman "Diğer" seçildiğinde
document.getElementById('department').addEventListener('change', function () {
    if (this.value === 'other') {
        const customDept = prompt('Lütfen departmanı yazınız:');
        if (customDept) {
            const option = document.createElement('option');
            option.value = customDept.toLowerCase();
            option.textContent = customDept;
            option.selected = true;
            this.appendChild(option);
        }
    }
});

// Karakter sayısı gösterimi
function addCharacterCounter(textareaId, maxLength = 500) {
    const textarea = document.getElementById(textareaId);
    const counter = document.createElement('small');
    counter.className = 'text-muted float-end';
    textarea.parentNode.appendChild(counter);

    function updateCounter() {
        const remaining = maxLength - textarea.value.length;
        counter.textContent = `${textarea.value.length}/${maxLength} karakter`;
        counter.style.color = remaining < 50 ? '#dc3545' : '#6c757d';
    }

    textarea.addEventListener('input', updateCounter);
    textarea.maxLength = maxLength;
    updateCounter();
}

document.getElementById("addLanguageBtn").addEventListener("click", function () {
    const container = document.getElementById("otherLanguagesContainer");
    const div = document.createElement("div");
    div.className = "input-group mb-2";
    div.innerHTML = `
    <input type="text" class="form-control" name="OtherLanguages[]" placeholder="Örn: Almanca (B2), Fransızca (A1)">
        <button class="btn btn-outline-danger removeLanguage" type="button">Sil</button>
        `;

    container.appendChild(div);
});

// Dinamik olarak eklenen silme butonlarını da destekle
document.getElementById("otherLanguagesContainer").addEventListener("click", function (e) {
    if (e.target.classList.contains("removeLanguage")) {
        e.target.parentElement.remove();
    }
});

// İş Tecrübesi için dinamik ekleme/silme
let workExperienceCount = 1;

document.getElementById('addWorkExperienceBtn').addEventListener('click', function () {
    const container = document.getElementById('workExperienceContainer');
    const newItem = container.children[0].cloneNode(true);

    // Input değerlerini temizle
    const inputs = newItem.querySelectorAll('input, textarea, select');
    inputs.forEach(input => {
        input.value = '';
        if (input.name) {
            input.name = input.name.replace(/\[0\]/, `[${workExperienceCount}]`);
        }
    });

    container.appendChild(newItem);
    workExperienceCount++;
});

document.addEventListener('click', function (e) {
    if (e.target.classList.contains('removeWorkExperience')) {
        if (document.querySelectorAll('.work-experience-item').length > 1) {
            e.target.closest('.work-experience-item').remove();
        }
    }
});

// Referanslar için dinamik ekleme/silme
let referenceCount = 1;

document.getElementById('addReferenceBtn').addEventListener('click', function () {
    const container = document.getElementById('referencesContainer');
    const newItem = container.children[0].cloneNode(true);

    const inputs = newItem.querySelectorAll('input');
    inputs.forEach(input => {
        input.value = '';
        if (input.name) {
            input.name = input.name.replace(/\[0\]/, `[${referenceCount}]`);
        }
    });

    container.appendChild(newItem);
    referenceCount++;
});

document.addEventListener('click', function (e) {
    if (e.target.classList.contains('removeReference')) {
        if (document.querySelectorAll('.reference-item').length > 1) {
            e.target.closest('.reference-item').remove();
        }
    }
});

// Sertifikalar için dinamik ekleme/silme
let certificateCount = 1;

document.getElementById('addCertificateBtn').addEventListener('click', function () {
    const container = document.getElementById('certificatesContainer');
    const newItem = container.children[0].cloneNode(true);

    const inputs = newItem.querySelectorAll('input, select');
    inputs.forEach(input => {
        input.value = '';
        if (input.name) {
            input.name = input.name.replace(/\[0\]/, `[${certificateCount}]`);
        }
    });

    container.appendChild(newItem);
    certificateCount++;
});

document.addEventListener('click', function (e) {
    if (e.target.classList.contains('removeCertificate')) {
        if (document.querySelectorAll('.certificate-item').length > 1) {
            e.target.closest('.certificate-item').remove();
        }
    }
});




addCharacterCounter('skills', 500);
addCharacterCounter('coverLetter', 1000);
addCharacterCounter('references', 300);

