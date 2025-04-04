using School.System.Samples;
using Xunit;

namespace School.System.EntityFrameworkCore.Domains;

[Collection(SystemTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<SystemEntityFrameworkCoreTestModule>
{

}
