using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Networks;
using Infrastructure.Cache;
using Infrastructure.Database;
using Xunit;

namespace WebApplication.Test;

public abstract class TestBase : IAsyncLifetime
{
    protected DatabaseConfig? DatabaseConfig = null;
    protected CacheConfig? CacheConfig = null;

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

        using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(1)); 
        INetwork network = null!;
        if (_options.UseTestContainers)
        {
             network = new NetworkBuilder()
                .WithName("network-" + Guid.NewGuid().ToString("D"))
                .WithCleanUp(true)
                .Build();
             await network.CreateAsync(cts.Token);
        }

        var createDataStoresTasks = new List<Task>();
        if (_options.UseDatabase)
        {
            createDataStoresTasks.Add(SetUpDatabaseContainerAsync(network, cts.Token));
        }

        if (_options.UseCache)
        {
            createDataStoresTasks.Add(SetUpCacheContainerAsync(network, cts.Token));
        }

        await Task.WhenAll(createDataStoresTasks);
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

        DatabaseConfig = new DatabaseConfig
        {
            ServerHost = databaseContainer.Hostname,
            ServerPort = databaseContainer.GetMappedPublicPort(mySqlPort).ToString(),
            ServerUser = "root",
            ServerPassword = "root"
        };
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

        var cacheContainer = new ContainerBuilder()
            .WithCleanUp(true)
            .WithName("cache-" + Guid.NewGuid().ToString("D"))
            .WithImage(cacheImage)
            .WithNetwork(network)
            .WithNetworkAliases(MagicNumberHost)
            .WithExposedPort(redisPort)
            .WithPortBinding(redisPort, true)
            .WithWaitStrategy(Wait.ForUnixContainer().UntilContainerIsHealthy(30))
            .Build();

        await cacheImage.CreateAsync(cancellationToken);
        await cacheContainer.StartAsync(cancellationToken);

        CacheConfig = new CacheConfig
        {
            Host = cacheContainer.Hostname,
            Port = cacheContainer.GetMappedPublicPort(redisPort).ToString(),
            User = "redis",
            Password = "redis"
        };
    }
}