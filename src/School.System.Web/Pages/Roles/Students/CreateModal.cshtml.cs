using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.System.Roles.Students;

namespace School.System.Web.Pages.Roles.Students;

public class CreateModalModel : SystemPageModel
{
    [BindProperty]
    public StudentCreateViewModel Student { get; set; }
        
    protected IStudentAppService _studentAppService;

    
    public CreateModalModel(IStudentAppService studentAppService)
    {
        _studentAppService = studentAppService;

        Student = new();
    }

    public virtual async Task OnGetAsync()
    {
        Student = new StudentCreateViewModel();

        await Task.CompletedTask;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        await _studentAppService.CreateAsync(ObjectMapper.Map<StudentCreateViewModel, CreateUpdateStudentDto>(Student));
        return NoContent();
    }
}

public class StudentCreateViewModel : CreateUpdateStudentDto
{
}
