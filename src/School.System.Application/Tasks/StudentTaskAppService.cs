using System;
using System.Threading.Tasks;
using School.System.Roles;
using School.System.Roles.Students;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace School.System.Tasks;

public class StudentTaskAppService:CrudAppService<StudentTask,StudentTaskDto,Guid,PagedAndSortedResultRequestDto,CreateUpdateStudentTaskDefinitionDto>,IStudentTaskAppService
{

    public StudentTaskAppService(
        IRepository<StudentTask, Guid> repository
       
    ) : base(repository)
    {
        
    }

   


}
