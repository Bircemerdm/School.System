using System;
using System.ComponentModel.DataAnnotations;

namespace School.System.Roles.Guardians;

public class CreateUpdateGuardianDto
{
    [Required]
    public string GuardianIdentificationNumber{get;set;}
    [Required]
    public string GuardianName{get;set;}=String.Empty;
    [Required]
    public string GuardianSurname{get;set;}=String.Empty;
    [Required]
    public string GuardianPhone{get;set;}
}