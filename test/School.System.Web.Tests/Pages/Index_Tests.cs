using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace School.System.Pages;

[Collection(SystemTestConsts.CollectionDefinitionName)]
public class Index_Tests : SystemWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
