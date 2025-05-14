using System;
using System.ComponentModel.DataAnnotations;
using School.System.Roles.Students;
using School.System.Roles.Teachers;

namespace School.System.Tasks
{
    public class CreateUpdateStudentTaskDefinitionDto
    {
        

        [Required]
        public StatusType Status { get; set; }

        // Let the controller or service assign CompletedAt only when the task is completed.
        public DateTime? CompletedAt { get; set; }

        [Required]
        public Guid AssignedTeacherId { get; set; }

        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public Guid TaskDefinitionId { get; set; }
    }
}