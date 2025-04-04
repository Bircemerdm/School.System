using Volo.Abp.Modularity;

namespace School.System;

[DependsOn(
    typeof(SystemDomainModule),
    typeof(SystemTestBaseModule)
)]
public class SystemDomainTestModule : AbpModule
{

}
