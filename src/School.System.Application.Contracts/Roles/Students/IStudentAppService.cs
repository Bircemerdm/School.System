using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace School.System.Roles.Students;

public interface IStudentAppService:ICrudAppService<StudentDto,Guid,PagedAndSortedResultRequestDto,CreateUpdateStudentDto>
{

}