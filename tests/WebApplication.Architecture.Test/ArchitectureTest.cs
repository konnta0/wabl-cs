using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NetArchTest.Rules;
using NetArchTest.Rules.Policies;
using Xunit;
using Xunit.Abstractions;

namespace WebApplication.Architecture.Test;

public class ArchitectureTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ArchitectureTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        Assembly.LoadFrom("WebAppBlueprintCS.dll");
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

    [Fact]
    public void ShouldNotPresentationDirectoryReferenceInfrastructure()
    {
        var result = Types.InAssembly(typeof(Presentation.Extension.ServiceCollectionExtension).Assembly)
            .That()
            .ResideInNamespaceStartingWith("Presentation")
            .ShouldNot()
            .HaveDependencyOn("Infrastructure")
            .GetResult();
        _testOutputHelper.WriteLine("Failure type names is ... " + string.Join("\n", result.FailingTypeNames ?? new List<string?>{"Nothing!!"}));

        Assert.True(result.IsSuccessful);
    }
    
    [Fact]
    public void InterfaceNamingPolicy()
    {
        var assemblies = new List<Assembly>
        {
            typeof(Application.Extension.ServiceCollectionExtension).Assembly,
            typeof(Domain.Entity.IHasSeed).Assembly,
            typeof(Domain.RestApi.IApi<,>).Assembly,
            typeof(Infrastructure.Extension.ServiceCollectionExtension).Assembly,
            typeof(Presentation.Extension.ServiceCollectionExtension).Assembly,
            typeof(Presentation.BackgroundService.Extension.ServiceCollectionExtension).Assembly,
        };

        var architecturePolicy = Policy
            .Define("InterfaceNamingPolicy", "Interface name should start with I")
            .For(Types.InAssemblies(assemblies))
            .Add(t =>
                    t.That()
                        .AreInterfaces()
                        .Should()
                        .HaveNameStartingWith("I"),
                "Generic implementation rules", "Interface names should start with an 'I'"
            );
        var results = architecturePolicy.Evaluate();
        results.Results
            .Where(static x => x.FailingTypes is not null)
            .Select(static x => x.FailingTypes)
            .ToList()
            .ForEach(x => _testOutputHelper.WriteLine("Failure type names is ... " + string.Join("\n", x)));

        Assert.False(results.HasViolations);
    }
}