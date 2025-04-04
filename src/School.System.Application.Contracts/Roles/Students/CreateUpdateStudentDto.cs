using System;
using System.ComponentModel.DataAnnotations;

namespace School.System.Roles.Students;

public class CreateUpdateStudentDto
{
    public Guid GuardianId { get; set; }
    public int StudentIdentificationNumber{get;set;}
    
    [Required]
    [StringLength(128)]
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
   
    public int? StudentPhone{get;set;}
}