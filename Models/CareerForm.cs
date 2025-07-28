using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class CareerForm
{
    // Kişisel Bilgiler
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Phone]
    public string Phone { get; set; }

    [Required]
    public string Nationality { get; set; } // "tc" / "foreign"

    public string Identity { get; set; } // T.C. Kimlik No

    [Required]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    [Required]
    public string Gender { get; set; } // "male" / "female"

    [Required]
    public string City { get; set; }

    [Required]
    public string MaritalStatus { get; set; }

    public string Address { get; set; }

    // Başvuru Bilgileri
    [Required]
    public string ApplicationType { get; set; }

    [Required]
    public string Department { get; set; }

    [Required]
    public string Position { get; set; }

    public string WorkLocation { get; set; }

    public string ExpectedSalary { get; set; }

    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }

    // Eğitim Bilgileri
    [Required]
    public string Education { get; set; }

    public int? GraduationYear { get; set; }

    public string University { get; set; }

    public double? GPA { get; set; }

    public string Major { get; set; }

    // Deneyim ve Yetenekler
    [Required]
    public string Experience { get; set; }

    public string CurrentSalary { get; set; }

    [Required]
    public string Skills { get; set; }

    public string EnglishLevel { get; set; }

    public List<string> OtherLanguages { get; set; } = new();

    public List<WorkExperience> WorkExperiences { get; set; } = new();

    public List<Reference> References { get; set; } = new();

    public List<Certificate> Certificates { get; set; } = new();

    // Belgeler
    [Required]
    public string CvFilePath { get; set; } // Dosya adını/path bilgisini tutar

    public string CoverLetter { get; set; }

    [Url]
    public string Portfolio { get; set; }

    // Onaylar
    [Required]
    public bool Consent { get; set; }

    public bool Marketing { get; set; }

    [Required]
    public bool Accuracy { get; set; }
}

public class WorkExperience
{
    public string Company { get; set; }
    public string Position { get; set; }
    public string StartMonth { get; set; }
    public int? StartYear { get; set; }
    public string EndMonth { get; set; }
    public int? EndYear { get; set; }
    public string Description { get; set; }
}

public class Reference
{
    public string Name { get; set; }
    public string Position { get; set; }
    public string Company { get; set; }
    [Phone]
    public string Phone { get; set; }
    [EmailAddress]
    public string Email { get; set; }
}

public class Certificate
{
    public string Name { get; set; }
    public int? Year { get; set; }
    public string Institution { get; set; }
    public string Validity { get; set; }
}
