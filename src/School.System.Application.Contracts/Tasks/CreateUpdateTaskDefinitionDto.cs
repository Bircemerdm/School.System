using System;
using System.ComponentModel.DataAnnotations;
using School.System.Roles.Teachers;

namespace School.System.Tasks;

public class CreateUpdateTaskDefinitionDto
{
    [Required]
    [StringLength(128)]
    public string Title { get; set; }= string.Empty;
    
    [Required]
    public string Description { get; set; }= string.Empty;
    
    [Required]
    public DateTime CreationDate { get; set; }=DateTime.Now;
    
    [Required]
    public DateTime AssignedDate { get; set; }=DateTime.Now;
    
    
    public Guid TeacherId { get; set; }
}