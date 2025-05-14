using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.System.Roles.Teachers;

namespace School.System.Web.Pages.Roles.Teachers;

public class CreateModalModel : SystemPageModel
{
    [BindProperty]
    public TeacherCreateViewModel Teacher { get; set; }
        
    protected ITeacherAppService _teacherAppService;

    
    public CreateModalModel(ITeacherAppService teacherAppService)
    {
        _teacherAppService = teacherAppService;

        Teacher = new();
    }

    public virtual async Task OnGetAsync()
    {
        Teacher = new TeacherCreateViewModel();

        await Task.CompletedTask;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        await _teacherAppService.CreateAsync(ObjectMapper.Map<TeacherCreateViewModel, CreateUpdateTeacherDto>(Teacher));
        return NoContent();
    }
}

public class TeacherCreateViewModel : CreateUpdateTeacherDto
{
}

    
