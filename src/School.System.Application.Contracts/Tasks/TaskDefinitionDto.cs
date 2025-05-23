using System;
using School.System.Roles.Teachers;
using Volo.Abp.Application.Dtos;

namespace School.System.Tasks;

public class TaskDefinitionDto:AuditedEntityDto<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    
    public DateTime DueDate { get; set; }
 
    public Guid TeacherId { get; set; }
}