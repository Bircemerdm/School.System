using School.System.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace School.System.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SystemEntityFrameworkCoreModule),
    typeof(SystemApplicationContractsModule)
)]
public class SystemDbMigratorModule : AbpModule
{
}
