using System;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using Infrastructure.Database.Context.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace WebApplication.Test;

public class TestContainersExample : TestBase
{
    protected override Task SetUpAsync()
    {
        Infrastructure.Extension.ServiceCollection.AddDbContexts(TestServiceCollection);
        return Task.CompletedTask;
    }

    [Fact]
    public async Task ExampleTest()
    {
        var employeesContext = TestServiceProvider.GetRequiredService<EmployeesContext>();
        await employeesContext.TitlesModels.ToListAsync();
        await Task.Delay(1);
    }

    [Fact]
    public async Task ExampleTest2()
    {
        await Task.Delay(1);
    }
}

public abstract class TestBase : IAsyncLifetime
{

    protected ServiceCollection TestServiceCollection;
    protected ServiceProvider TestServiceProvider;
    private const string MagicNumberHost = "deep-thought";
    
    public async Task InitializeAsync()
    { 
        await SetUpCoreAsync();
    }

    public Task DisposeAsync()
    {
        return TearDownAsync();
    }

    protected virtual Task SetUpAsync()
    {
        return Task.CompletedTask;
    }
    
    protected virtual Task TearDownAsync()
    {
        return Task.CompletedTask;
    }
    
    private async Task SetUpCoreAsync()
    {
        TestServiceCollection = new ServiceCollection();
        TestServiceCollection.AddLogging();

        var network = new NetworkBuilder()
            .WithName("network-" + Guid.NewGuid().ToString("D"))
            .WithCleanUp(true)
            .Build();

        var solutionDirectory = CommonDirectoryPath.GetSolutionDirectory();
        var databaseImage = new ImageFromDockerfileBuilder()
            .WithDockerfileDirectory(solutionDirectory, string.Empty)
            .WithDockerfile("Dockerfile.MySQL")
            .WithName("test-" + Guid.NewGuid().ToString("D"))
            .WithCleanUp(true)
            .Build();

        var databaseContainer = new ContainerBuilder()
            .WithName("db-" + Guid.NewGuid().ToString("D"))
            .WithImage(databaseImage)
            .WithNetwork(network)
            .WithNetworkAliases(MagicNumberHost)
            .WithExposedPort(3306)
            .WithPortBinding(3306, true)
            .WithEnvironment("MYSQL_ROOT_PASSWORD", "root")
            .WithEnvironment("MYSQL_ALLOW_EMPTY_PASSWORD", string.Empty)
            .WithEnvironment("MYSQL_RANDOM_ROOT_PASSWORD", string.Empty)
            .WithWaitStrategy(Wait.ForUnixContainer().UntilContainerIsHealthy(30))
            .Build();

        using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(1)); 
        await network.CreateAsync(cts.Token);
        await databaseImage.CreateAsync(cts.Token);
        await databaseContainer.StartAsync(cts.Token);

        Environment.SetEnvironmentVariable("DB_SERVER_HOST", databaseContainer.Hostname);
        Environment.SetEnvironmentVariable("DB_SERVER_PORT", databaseContainer.GetMappedPublicPort(3306).ToString());
        Environment.SetEnvironmentVariable("DB_SERVER_USER", "root");
        Environment.SetEnvironmentVariable("DB_SERVER_PASSWORD", "root");
        
        await SetUpAsync();
        TestServiceProvider = TestServiceCollection.BuildServiceProvider();
    }
}