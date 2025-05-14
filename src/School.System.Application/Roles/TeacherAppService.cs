using System;
using School.System.Roles.Teachers;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace School.System.Roles;

public class TeacherAppService:CrudAppService<Teacher,TeacherDto,Guid,PagedAndSortedResultRequestDto,CreateUpdateTeacherDto>,ITeacherAppService
{
    public TeacherAppService(IRepository<Teacher, Guid> repository) : base(repository)
    {
        
    }
    
}