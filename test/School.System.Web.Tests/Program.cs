using Microsoft.AspNetCore.Builder;
using School.System;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("School.System.Web.csproj"); 
await builder.RunAbpModuleAsync<SystemWebTestModule>(applicationName: "School.System.Web");

public partial class Program
{
}
