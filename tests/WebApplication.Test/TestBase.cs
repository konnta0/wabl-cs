using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Networks;
using Xunit;

namespace WebApplication.Test;

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

        if (_options.UseCache)
        {
            await SetUpCacheContainerAsync(network, cts.Token);
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
            .WithName("db-" + Guid.NewGuid().ToString("D"))
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

    private async Task SetUpCacheContainerAsync(INetwork network, CancellationToken cancellationToken)
    {
        const int redisPort = 6379;
        var solutionDirectory = CommonDirectoryPath.GetSolutionDirectory();
        var cacheImage = new ImageFromDockerfileBuilder()
            .WithDockerfileDirectory(solutionDirectory, "tests")
            .WithDockerfile("Dockerfile.Redis")
            .WithName("cache-" + Guid.NewGuid().ToString("D"))
            .WithCleanUp(true)
            .Build();

        var databaseContainer = new ContainerBuilder()
            .WithCleanUp(true)
            .WithName("cache-" + Guid.NewGuid().ToString("D"))
            .WithImage(cacheImage)
            .WithNetwork(network)
            .WithNetworkAliases(MagicNumberHost)
            .WithExposedPort(redisPort)
            .WithPortBinding(redisPort, true)
            .WithEnvironment("MYSQL_ROOT_PASSWORD", "root")
            .WithEnvironment("MYSQL_ALLOW_EMPTY_PASSWORD", string.Empty)
            .WithEnvironment("MYSQL_RANDOM_ROOT_PASSWORD", string.Empty)
            .WithWaitStrategy(Wait.ForUnixContainer().UntilContainerIsHealthy(30))
            .Build();

        await cacheImage.CreateAsync(cancellationToken);
        await databaseContainer.StartAsync(cancellationToken);
    }
}