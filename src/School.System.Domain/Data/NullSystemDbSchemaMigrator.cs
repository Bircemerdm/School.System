using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace School.System.Data;

/* This is used if database provider does't define
 * ISystemDbSchemaMigrator implementation.
 */
public class NullSystemDbSchemaMigrator : ISystemDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
