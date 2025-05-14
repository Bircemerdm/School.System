using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace School.System.Roles;

public class Guardian:FullAuditedAggregateRoot<Guid>
{
    public string GuardianIdentificationNumber{get;set;}
    public string GuardianName{get;set;}
    public string GuardianSurname{get;set;}
    public string GuardianPhone{get;set;}
    
}