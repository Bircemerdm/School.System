using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.System.Roles.Guardians;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace School.System.Web.Pages.Roles.Guardians;

public class IndexModel : AbpPageModel
{
    protected IGuardianAppService _guardianAppService;

    public IndexModel(IGuardianAppService guardianAppService)
    {
        _guardianAppService = guardianAppService;
    }

    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}