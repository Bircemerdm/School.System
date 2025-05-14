using System;
using System.Threading.Tasks;
using School.System.Roles.Students;
using School.System.Roles.Teachers;
using Volo.Abp.Application.Dtos;

namespace School.System.Tasks;

public class StudentTaskDto:AuditedEntityDto<Guid>
{
    public StatusType Status { get; set; }
    public DateTime? CompletedAt { get; set; }
    
    public Guid AssignedTeacherId { get; set; }
    public Guid StudentId { get; set; }
    public Guid TaskDefinitionId { get; set; }
}