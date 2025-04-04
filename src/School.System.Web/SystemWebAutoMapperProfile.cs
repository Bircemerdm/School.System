using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.System.Roles;
using School.System.Roles.Students;
using School.System.Web.Pages.Roles.Students;

namespace School.System.Web;

public class SystemWebAutoMapperProfile : Profile
{
    public SystemWebAutoMapperProfile()
    {
        CreateMap<StudentDto,StudentUpdateViewModel>();
        CreateMap<StudentUpdateViewModel,StudentDto>();
        CreateMap<StudentDto, CreateUpdateStudentDto>();
        CreateMap<StudentCreateViewModel, Student>();
        CreateMap<StudentUpdateViewModel, Student>();

        //Define your object mappings here, for the Web project
    }
}
