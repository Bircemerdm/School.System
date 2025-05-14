using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;

namespace School.System.Tasks;

public interface IStudentTaskAppService:ICrudAppService<StudentTaskDto,Guid,PagedAndSortedResultRequestDto,CreateUpdateStudentTaskDefinitionDto>
{
   
}