using System;
using School.System.Roles.Students;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace School.System.Roles.Guardians;

public interface IGuardianAppService:ICrudAppService <GuardianDto,Guid,PagedAndSortedResultRequestDto,CreateUpdateGuardianDto>
{
    
}