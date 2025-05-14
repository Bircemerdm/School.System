using System;
using Volo.Abp.Application.Dtos;

namespace School.System.Roles.Guardians;

public class GuardianDto:AuditedEntityDto<Guid>
{
    public string GuardianIdentificationNumber{get;set;}
    public string GuardianName{get;set;}
    public string GuardianSurname{get;set;}
    public string GuardianPhone{get;set;}
}