using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using School.System.Localization;

namespace School.System.Web;

[Dependency(ReplaceServices = true)]
public class SystemBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<SystemResource> _localizer;

    public SystemBrandingProvider(IStringLocalizer<SystemResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
