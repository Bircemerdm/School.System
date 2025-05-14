using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.System.Roles;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace School.System.Tasks;

public class TaskDefinitionAppService:CrudAppService<TaskDefinition,TaskDefinitionDto,Guid,PagedAndSortedResultRequestDto,CreateUpdateTaskDefinitionDto>,ITaskDefinitionAppService
{
   

    public TaskDefinitionAppService(
        IRepository<TaskDefinition, Guid> repository
    ) : base(repository){}
    
}
