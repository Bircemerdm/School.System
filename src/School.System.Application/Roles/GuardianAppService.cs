using System;
using School.System.Roles.Guardians;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace School.System.Roles;

public class GuardianAppService:CrudAppService<Guardian,GuardianDto,Guid,  PagedAndSortedResultRequestDto, CreateUpdateGuardianDto>,Guardians.IGuardianAppService
{
    public GuardianAppService(IRepository<Guardian, Guid> repository)
        : base(repository)
    {
        
    }
}