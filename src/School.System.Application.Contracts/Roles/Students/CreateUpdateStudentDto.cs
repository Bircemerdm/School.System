using System;
using System.ComponentModel.DataAnnotations;

namespace School.System.Roles.Students;

public class CreateUpdateStudentDto
{
    public Guid GuardianId { get; set; }
    public string StudentIdentificationNumber{get;set;}
    
    [Required]
    [StringLength(128)]
    [RegularExpression(@"^[A-ZÇĞİÖŞÜ][a-zçğıöşü]{1,19}( [A-ZÇĞİÖŞÜ][a-zçğıöşü]{1,19})*$", ErrorMessage = "Lütfen geçerli bir isim giriniz.")]
    public string StudentName{get;set;}= string.Empty;
    
    [Required]
    public string StudentSurname{get;set;}= string.Empty;
   
    [DataType(DataType.Date)]
    public DateTime? StudentBirthday{get;set;}= DateTime.Now;
    [Required]
    public ClassType Class{get;set;}
    [Required]
    public string Brach{get;set;}
    [Required]
    public float SchoolFee{get;set;}
   //[RegularExpression(@"^\(5\d{2}\) \d{3} \d{2} \d{2}$", ErrorMessage = "Lütfen '(5XX) XXX XX XX' formatında bir telefon numarası giriniz.")]
    public string? StudentPhone{get;set;}
}