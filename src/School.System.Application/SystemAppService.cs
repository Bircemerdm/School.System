using School.System.Localization;
using Volo.Abp.Application.Services;

namespace School.System;

/* Inherit your application services from this class.
 */
public abstract class SystemAppService : ApplicationService
{
    protected SystemAppService()
    {
        LocalizationResource = typeof(SystemResource);
    }
}
