using System.Threading.Tasks;

namespace School.System.Data;

public interface ISystemDbSchemaMigrator
{
    Task MigrateAsync();
}
