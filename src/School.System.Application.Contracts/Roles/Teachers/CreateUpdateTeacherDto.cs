using System;
using System.ComponentModel.DataAnnotations;

namespace School.System.Roles.Teachers;

public class CreateUpdateTeacherDto
{
    [Required]
    public string TeacherIdentificationNumber{get;set;}
    [Required]
    [StringLength(50)]
    public string TeacherName{get;set;}=String.Empty;
    [Required]
    [StringLength(50)]
    public string TeacherSurname{get;set;}=String.Empty;
    [Required]
    public BranchType Type{get;set;}
    
    public DateTime? TeacherBirthday{get;set;}
    
    public string? TeacherPhone{get;set;}
    
    public float? Salary{get;set;}
}