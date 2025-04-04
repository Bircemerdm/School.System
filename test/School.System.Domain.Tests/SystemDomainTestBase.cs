using Volo.Abp.Modularity;

namespace School.System;

/* Inherit from this class for your domain layer tests. */
public abstract class SystemDomainTestBase<TStartupModule> : SystemTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
