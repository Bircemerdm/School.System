using System;
using School.System.Roles;
using Volo.Abp.Domain.Entities.Auditing;

namespace School.System.Tasks;

public class StudentTask:FullAuditedAggregateRoot<Guid>
{
    public Guid TaskDefinitionId { get; set; }
    public Guid StudentId { get; set; }
    public Guid AssignedTeacherId { get; set; }
    
    public StatusType Status { get; set; }
    public DateTime? CompletedAt { get; set; }
    
    
}