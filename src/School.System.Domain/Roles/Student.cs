using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace School.System.Roles;

public class Student:FullAuditedAggregateRoot<Guid>
{
    public Guid GuardianId { get; set; }
    public int StudentIdentificationNumber{get;set;}
    
    public string StudentName{get;set;}
    public string StudentSurname{get;set;}
    public DateTime? StudentBirthday{get;set;}
    public ClassType Class{get;set;}
    public string Brach{get;set;}
    public float SchoolFee{get;set;}
    public int? StudentPhone{get;set;}
    
}