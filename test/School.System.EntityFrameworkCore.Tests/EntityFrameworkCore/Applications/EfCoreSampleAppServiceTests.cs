using School.System.Samples;
using Xunit;

namespace School.System.EntityFrameworkCore.Applications;

[Collection(SystemTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<SystemEntityFrameworkCoreTestModule>
{

}
