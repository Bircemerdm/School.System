using School.System.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace School.System.Web.Pages;

public abstract class SystemPageModel : AbpPageModel
{
    protected SystemPageModel()
    {
        LocalizationResourceType = typeof(SystemResource);
    }
}
