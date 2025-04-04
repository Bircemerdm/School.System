using AutoMapper;
using School.System.Roles;
using School.System.Roles.Guardians;
using School.System.Roles.Students;

namespace School.System;

public class SystemApplicationAutoMapperProfile : Profile
{
    public SystemApplicationAutoMapperProfile()
    {
        CreateMap<Student, StudentDto>();
        CreateMap<StudentDto, Student>();
        CreateMap<Guardian, GuardianDto>();


        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
