using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace School.System.Tasks;

public interface ITaskDefinitionAppService:ICrudAppService<TaskDefinitionDto,Guid,PagedAndSortedResultRequestDto,CreateUpdateTaskDefinitionDto>
{
    
}