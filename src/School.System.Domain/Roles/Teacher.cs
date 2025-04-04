using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace School.System.Roles;

public class Teacher: FullAuditedAggregateRoot<Guid>
{
    public int TeacherIdentificationNumber{get;set;}
    public string TeacherName{get;set;}
    public string TeacherSurname{get;set;}
    public BranchType Type{get;set;}
    public DateTime? TeacherBirthday{get;set;}
    public int? TeacherPhone{get;set;}
    public float? Salary{get;set;}
    
}