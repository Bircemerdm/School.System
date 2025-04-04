using Volo.Abp.Modularity;

namespace School.System;

public abstract class SystemApplicationTestBase<TStartupModule> : SystemTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
