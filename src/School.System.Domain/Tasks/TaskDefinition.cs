using System;
using System.Collections.Generic;
using School.System.Roles;
using Volo.Abp.Domain.Entities.Auditing;
 
namespace School.System.Tasks;
 
public class TaskDefinition:FullAuditedAggregateRoot<Guid>
{
  
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid TeacherId { get; set; } 
    public DateTime DueDate { get; set; }
}