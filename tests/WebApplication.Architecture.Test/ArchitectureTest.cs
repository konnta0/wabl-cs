using System.Collections.Generic;
using System.Reflection;
using NetArchTest.Rules;
using Xunit;
using Xunit.Abstractions;

namespace WebApplication.Architecture.Test;

public class ArchitectureTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ArchitectureTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        Assembly.LoadFrom("DotnetMetricTestApp.dll");
    }
    
    [Fact]
    public void ShouldNotPresentationDirectoryReferenceRepository()
    {
        var result = Types.InNamespace("Presentation.Controllers")
            .That()
            .ResideInNamespace("Presentation.Controllers")
            .ShouldNot()
            .HaveDependencyOn("Infrastructure.Repository")
            .GetResult();
        _testOutputHelper.WriteLine("Failure type names is ... " + string.Join("\n", result.FailingTypeNames ?? new List<string?>{"Nothing!!"}));

        Assert.True(result.IsSuccessful);
    }
}