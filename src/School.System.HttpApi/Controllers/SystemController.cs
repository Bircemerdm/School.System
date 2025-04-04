using School.System.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace School.System.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SystemController : AbpControllerBase
{
    protected SystemController()
    {
        LocalizationResource = typeof(SystemResource);
    }
}
