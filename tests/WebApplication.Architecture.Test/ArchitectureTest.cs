using System.Reflection;
using NetArchTest.Rules;
using Xunit;

namespace WebApplication.Architecture.Test;

public class ArchitectureTest
{
    public ArchitectureTest()
    {
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
            .GetResult()
            .IsSuccessful;
        Assert.True(result);
    }
}