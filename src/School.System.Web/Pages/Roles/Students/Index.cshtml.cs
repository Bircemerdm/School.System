using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.System.Roles.Students;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace School.System.Web.Pages.Roles.Students;

public class IndexModel : AbpPageModel
{
    protected IStudentAppService _studentAppService;

    public IndexModel(IStudentAppService studentAppService)
    {
        _studentAppService = studentAppService;
    }

    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}