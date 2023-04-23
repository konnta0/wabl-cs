using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using Domain.Entity.Employee;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Networks;
using FluentAssertions;
using Infrastructure.Database.Context.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace WebApplication.Test;

public class TestContainersExample : TestBase
{
    private IServiceProvider? _serviceProvider;

    protected override async Task SetUpAsync()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddLogging();
        Infrastructure.Extension.ServiceCollection.AddDbContexts(serviceCollection);
        
        _serviceProvider = serviceCollection.BuildServiceProvider();
        var employeesContext = _serviceProvider!.GetRequiredService<EmployeesContext>();
        await employeesContext.Database.MigrateAsync();
        await employeesContext.Database.EnsureCreatedAsync();
    }

    [Fact]
    public async Task ExampleTest()
    {
        var employeesContext = _serviceProvider!.GetRequiredService<EmployeesContext>();
        
        var testTitleEntities = new Faker<TitlesEntity>()
            .RuleFor(x => x.EmpNo, f => f.Random.Int(1, 1000000))
            .RuleFor(x => x.Title, f => f.Random.Guid().ToString())
            .RuleFor(x => x.FromDate, f => f.Date.Past())
            .RuleFor(x => x.ToDate, f => f.Date.Future());

        var generated = testTitleEntities.Generate(100);
        await employeesContext.TitlesEntities.AddRangeAsync(generated);

        var faker = new Faker("ja");
        var employeeEntities = new List<EmployeesEntity>();
        foreach (var titleEntity in generated)
        {
            employeeEntities.Add(new EmployeesEntity
            {
                EmpNo = titleEntity.EmpNo,
                BirthDate = faker.Date.Past(),
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                Gender = faker.Random.Enum<EmployeesEntity.GenderType>(),
                HireDate = faker.Date.Past()
            });
        }
        await employeesContext.EmployeesEntities.AddRangeAsync(employeeEntities);
        
        await employeesContext.SaveChangesAsync();
        
        var newTitleEntities = await employeesContext.TitlesEntities.ToListAsync();
        newTitleEntities.Should().HaveCount(100);
    }

    [Fact]
    public async Task ExampleTest2()
    {
        await Task.Delay(1);
    }
}

public abstract class TestBase : IAsyncLifetime
{

    private const string MagicNumberHost = "deep-thought";
    private readonly TestBaseOptions _options;
    
    protected class TestBaseOptions
    {
        public bool UseDatabase { get; set; } = true;
        public bool UseCache { get; set; } = true;

        public bool UseTestContainers => UseDatabase || UseCache;
    }

    protected TestBase(Action<TestBaseOptions>? options = null)
    {
        _options = new TestBaseOptions();
        options?.Invoke(_options);
    }
    
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
        await SetEnvironmentVariablesAsync();

        using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(5)); 
        INetwork network = null!;
        if (_options.UseTestContainers)
        {
             network = new NetworkBuilder()
                .WithName("network-" + Guid.NewGuid().ToString("D"))
                .WithCleanUp(true)
                .Build();
             await network.CreateAsync(cts.Token);
        }

        if (_options.UseDatabase)
        {
            await SetUpDatabaseContainerAsync(network, cts.Token);
        }

        await SetUpAsync();
    }
    
    private async Task SetEnvironmentVariablesAsync()
    {
        var solutionDirectory = CommonDirectoryPath.GetSolutionDirectory();
        var dotEnvFile = Path.Combine(solutionDirectory.DirectoryPath, ".env");
        if (!File.Exists(dotEnvFile))
        {
            return;
        }

        var lines = await File.ReadAllLinesAsync(dotEnvFile);
        foreach (var line in lines)
        {
            var parts = line.Split("=", 2);
            if (parts.Length != 2)
            {
                continue;
            }

            Environment.SetEnvironmentVariable(parts[0], parts[1]);
        }
        
    }
    
    private async Task SetUpDatabaseContainerAsync(INetwork network, CancellationToken cancellationToken)
    {
        const int mySqlPort = 3306;
        var solutionDirectory = CommonDirectoryPath.GetSolutionDirectory();
        var databaseImage = new ImageFromDockerfileBuilder()
            .WithDockerfileDirectory(solutionDirectory, "tests")
            .WithDockerfile("Dockerfile.MySQL")
            .WithName("test-" + Guid.NewGuid().ToString("D"))
            .WithCleanUp(true)
            .Build();

        var databaseContainer = new ContainerBuilder()
            .WithCleanUp(true)
            .WithName("db-" + Guid.NewGuid().ToString("D"))
            .WithImage(databaseImage)
            .WithNetwork(network)
            .WithNetworkAliases(MagicNumberHost)
            .WithExposedPort(mySqlPort)
            .WithPortBinding(mySqlPort, true)
            .WithEnvironment("MYSQL_ROOT_PASSWORD", "root")
            .WithEnvironment("MYSQL_ALLOW_EMPTY_PASSWORD", string.Empty)
            .WithEnvironment("MYSQL_RANDOM_ROOT_PASSWORD", string.Empty)
            .WithWaitStrategy(Wait.ForUnixContainer().UntilContainerIsHealthy(30))
            .Build();

        await databaseImage.CreateAsync(cancellationToken);
        await databaseContainer.StartAsync(cancellationToken);
        
        Environment.SetEnvironmentVariable("DB_SERVER_HOST", databaseContainer.Hostname);
        Environment.SetEnvironmentVariable("DB_SERVER_PORT", databaseContainer.GetMappedPublicPort(mySqlPort).ToString());
        Environment.SetEnvironmentVariable("DB_SERVER_USER", "root");
        Environment.SetEnvironmentVariable("DB_SERVER_PASSWORD", "root");
    }
}