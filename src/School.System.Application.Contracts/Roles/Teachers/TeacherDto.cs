using System;
using Volo.Abp.Application.Dtos;

namespace School.System.Roles.Teachers;

public class TeacherDto:AuditedEntityDto<Guid>
{
    public int TeacherIdentificationNumber{get;set;}
    public string TeacherName{get;set;}
    public string TeacherSurname{get;set;}
    public BranchType Type{get;set;}
    public DateTime? TeacherBirthday{get;set;}
    public int? TeacherPhone{get;set;}
    public float? Salary{get;set;}
}