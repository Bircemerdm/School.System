using Volo.Abp.Modularity;

namespace School.System;

[DependsOn(
    typeof(SystemApplicationModule),
    typeof(SystemDomainTestModule)
)]
public class SystemApplicationTestModule : AbpModule
{

}
