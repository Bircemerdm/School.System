using AutoMapper;
using School.System.Documents;
using School.System.Roles;
using School.System.Roles.Guardians;
using School.System.Roles.Students;
using School.System.Roles.Teachers;
using School.System.Tasks;

namespace School.System;

public class SystemApplicationAutoMapperProfile : Profile
{
    public SystemApplicationAutoMapperProfile()
    {
        CreateMap<Student, StudentDto>();
        CreateMap<StudentDto, Student>();
        CreateMap<Guardian, GuardianDto>();
        CreateMap<Teacher, TeacherDto>();
        CreateMap<Document, DocumentDto>().ReverseMap();

        CreateMap<CreateUpdateTaskDefinitionDto, TaskDefinition>();
        CreateMap<CreateUpdateStudentTaskDefinitionDto, StudentTask>();
        
        CreateMap<TaskDefinitionDto , TaskDefinition>().ReverseMap();
        CreateMap<StudentTask, StudentTaskDto>().ReverseMap();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
