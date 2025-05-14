using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace School.System.Roles.Teachers;

public interface ITeacherAppService:ICrudAppService<TeacherDto,Guid,PagedAndSortedResultRequestDto,CreateUpdateTeacherDto>
{
    
}