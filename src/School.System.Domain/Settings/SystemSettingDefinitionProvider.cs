using Volo.Abp.Settings;

namespace School.System.Settings;

public class SystemSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(SystemSettings.MySetting1));
    }
}
