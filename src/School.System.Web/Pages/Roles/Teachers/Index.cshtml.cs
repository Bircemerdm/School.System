using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.System.Roles.Teachers;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace School.System.Web.Pages.Roles.Teachers;

public class IndexModel : AbpPageModel
{
    protected ITeacherAppService _teacherAppService;

    public IndexModel(ITeacherAppService teacherAppService)
    {
        _teacherAppService = teacherAppService;
    }

    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}