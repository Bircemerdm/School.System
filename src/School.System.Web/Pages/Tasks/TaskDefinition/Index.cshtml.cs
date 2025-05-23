using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.System.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace School.System.Web.Pages.Tasks.TaskDefinition;
public class IndexModel : AbpPageModel
{
    protected ITaskDefinitionAppService _taskDefinitionAppService;

    public IndexModel(ITaskDefinitionAppService taskDefinitionAppService)
    {
        _taskDefinitionAppService = taskDefinitionAppService;
    }

    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}