using System;
using Volo.Abp.Application.Dtos;

namespace School.System.Roles.Students;

public class StudentDto:AuditedEntityDto<Guid>
{
    public Guid GuardianId { get; set; }
    public string StudentIdentificationNumber{get;set;}
    
    public string StudentName{get;set;}
    public string StudentSurname{get;set;}
    public DateTime? StudentBirthday{get;set;}
    public ClassType Class{get;set;}
    public string Brach{get;set;}
    public float SchoolFee{get;set;}
    public string? StudentPhone{get;set;}
}