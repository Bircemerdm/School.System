using System;
using System.Threading.Tasks;
using School.System.Roles.Students;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace School.System.Roles;

public class StudentAppService :
    CrudAppService<
        Student,StudentDto,Guid,  PagedAndSortedResultRequestDto, CreateUpdateStudentDto>, Students.IStudentAppService
{
    public StudentAppService(IRepository<Student, Guid> repository)
        : base(repository)
    {
        
    }

    
}