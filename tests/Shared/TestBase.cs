using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using DotNet.Testcontainers.Networks;
using Testcontainers.MySql;
using WebApplication.Infrastructure.Cache;
using WebApplication.Infrastructure.Database;
using Xunit;

namespace Shared;

public abstract class TestBase : IAsyncLifetime
{
    protected DatabaseConfig? DatabaseConfig;
    protected CacheConfig? CacheConfig;

    private const string MagicNumberHost = "deep-thought";
    private readonly TestBaseOptions _options;
    private INetwork? _network;
    private IContainer[] _containers;
    private bool _disposed;
    
    protected class TestBaseOptions
    {
        public bool UseDatabase { get; set; } = true;
        public bool UseCache { get; set; } = true;

        public bool UseTestContainers => UseDatabase || UseCache;
    }

    protected TestBase(Action<TestBaseOptions>? options = null)
    {
        _containers = Array.Empty<IContainer>();
        _options = new TestBaseOptions();
        options?.Invoke(_options);
    }

    public async Task InitializeAsync()
    { 
        await SetUpCoreAsync();
    }

    public async Task DisposeAsync()
    {
        if (_disposed) return;
        await TearDownAsync();
        foreach (var container in _containers)
        {
            await container.DisposeAsync();
        }
        _containers = Array.Empty<IContainer>();
        
        if (_network != null)
        {
            await _network.DeleteAsync();
        }
        _disposed = true;
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
        if (_options.UseTestContainers)
        {
             _network = new NetworkBuilder()
                .WithName("network-" + Guid.NewGuid().ToString("D"))
                .WithCleanUp(true)
                .Build();
             await _network.CreateAsync(cts.Token);
        }

        var createDataStoresTasks = new List<Task<IContainer>>();
        if (_options.UseDatabase)
        {
            createDataStoresTasks.Add(SetUpDatabaseContainerAsync(_network, cts.Token));
        }

        if (_options.UseCache)
        {
            createDataStoresTasks.Add(SetUpCacheContainerAsync(_network, cts.Token));
        }

        _containers = await Task.WhenAll(createDataStoresTasks);
        await SetUpAsync();
    }
    
    private async Task SetEnvironmentVariablesAsync()
    {
        var solutionDirectory = CommonDirectoryPath.GetSolutionDirectory();
        var dotEnvFile = Path.Combine(solutionDirectory.DirectoryPath, "./tests/WebApplication.Test/.env");
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
    
    private async Task<IContainer> SetUpDatabaseContainerAsync(INetwork? network, CancellationToken cancellationToken)
    {
        const int mySqlPort = 3306;
        var solutionDirectory = CommonDirectoryPath.GetSolutionDirectory();
        var databaseImage = new ImageFromDockerfileBuilder()
            .WithDockerfileDirectory(solutionDirectory, "tests")
            .WithDockerfile("Dockerfile.MySQL")
            .WithName("db-" + Guid.NewGuid().ToString("D"))
            .Build();

        var databaseContainer = new ContainerBuilder()
            .WithName("db-" + Guid.NewGuid().ToString("D"))
            .WithImage(databaseImage)
            .WithNetwork(network)
            .WithNetworkAliases(MagicNumberHost)
            .WithExposedPort(mySqlPort)
            .WithPortBinding(mySqlPort, true)
            .WithEnvironment("MYSQL_ROOT_PASSWORD", "root")
            .WithEnvironment("MYSQL_ALLOW_EMPTY_PASSWORD", string.Empty)
            .WithEnvironment("MYSQL_RANDOM_ROOT_PASSWORD", string.Empty)
            .WithEnvironment("MYSQL_DATABASE", "test")
            .WithWaitStrategy(Wait.ForUnixContainer().AddCustomWaitStrategy(new MysqlWaitUntil()))
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

        return databaseContainer;
    }

    private async Task<IContainer> SetUpCacheContainerAsync(INetwork? network, CancellationToken cancellationToken)
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

        return cacheContainer;
    }
    
    private sealed class MysqlWaitUntil : IWaitUntil
    {
        private readonly IList<string> _command;
        
        public MysqlWaitUntil(string user = "root", string password = "root", string database = "test")
        {
            _command = new List<string> { "mysql", "--protocol=TCP", $"--port={MySqlBuilder.MySqlPort}", $"--user={user}", $"--password={password}", database, "--wait", "--silent", "--execute=SELECT 1;" };
        }

        /// <inheritdoc />
        public async Task<bool> UntilAsync(IContainer container)
        {
            var execResult = await container.ExecAsync(_command)
                .ConfigureAwait(false);

            return 0L.Equals(execResult.ExitCode);
        }
    }

}