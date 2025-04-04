using Xunit;

namespace School.System.EntityFrameworkCore;

[CollectionDefinition(SystemTestConsts.CollectionDefinitionName)]
public class SystemEntityFrameworkCoreCollection : ICollectionFixture<SystemEntityFrameworkCoreFixture>
{

}
