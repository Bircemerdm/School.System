using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.System.Roles;
using School.System.Roles.Students;

namespace School.System.Web.Pages.Roles.Students;

public class EditModalModel : SystemPageModel
{
   [HiddenInput]
   [BindProperty(SupportsGet = true)]
   public Guid Id { get; set; }
   
   [BindProperty]
   public StudentUpdateViewModel Student { get; set; }
   
   protected IStudentAppService _studentAppService;

   public EditModalModel(IStudentAppService studentAppService)
   {
      _studentAppService = studentAppService;
      Student = new();
      
   }

   public virtual async Task OnGetAsync()
   {
      var studentDto= await _studentAppService.GetAsync(Id);
      Student = ObjectMapper.Map<StudentDto,StudentUpdateViewModel>(studentDto);
   }

   public virtual async Task<NoContentResult> OnPostAsync()
   {
      await _studentAppService.UpdateAsync(Id,ObjectMapper.Map<StudentUpdateViewModel, CreateUpdateStudentDto>(Student));
      return NoContent();
   }


}
public class StudentUpdateViewModel : CreateUpdateStudentDto
{
      
}