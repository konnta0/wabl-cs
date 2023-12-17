using System;
using System.Threading.Tasks;
using FluentAssertions;
using WebApplication.Infrastructure.Cache;
using WebApplication.Infrastructure.Core.Time;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Shared;
using Xunit;

namespace WebApplication.Infrastructure.Test.Core.Time;

public sealed class TimeProviderTest() : TestBase(options =>
{
    options.UseCache = false;
    options.UseDatabase = false;
})
{
    private IServiceProvider? _serviceProvider;

    protected override Task SetUpAsync()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddLogging();

        _serviceProvider = serviceCollection.BuildServiceProvider();
        return Task.CompletedTask;
    }

    [Fact]
    public async Task LocalNow()
    {
        var zonedTimeProvider = new ZonedTimeProvider(new TimeConfig
        {
            TimeZoneId = "Asia/Tokyo"
        });
        var dateTime = DateTimeOffset.Now.ToOffset(TimeSpan.FromHours(9));
        var now = zonedTimeProvider.GetLocalNow();

        now.Should().BeCloseTo(dateTime, TimeSpan.FromMilliseconds(200));

        await Task.Delay(200);
        var now2 = zonedTimeProvider.GetLocalNow();
        now.Should().NotBe(now2);
        now2.Should().BeCloseTo(now, TimeSpan.FromMilliseconds(300));
    }

    [Fact]
    public async Task Fixed()
    {
        var zonedTimeProvider = new ZonedFixedTimeProvider(new TimeConfig
        {
            TimeZoneId = "Asia/Tokyo"
        });
        var dateTime = DateTimeOffset.Now.ToOffset(TimeSpan.FromHours(9));
        var now = zonedTimeProvider.GetLocalNow();
        now.Should().BeCloseTo(dateTime, TimeSpan.FromMilliseconds(200));
        await Task.Delay(200);
        var now2 = zonedTimeProvider.GetLocalNow();
        now.Should().Be(now2);
    }

    [Fact]
    public void WithServiceCollection()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddScoped<IDurableRedisProvider>(_ =>
        {
            var mock = Substitute.For<IDurableRedisProvider>();
            return mock;
        });
        serviceCollection.AddSingleton<IWebHostEnvironment>(_ =>
        {
            var mock = Substitute.For<IWebHostEnvironment>();
            mock.EnvironmentName.Returns("Production");
            return mock;
        });
        
        var serviceProvider = serviceCollection.BuildServiceProvider();
        serviceCollection.AddScoped<TimeProvider>(_ =>
        {
            var durableRedisProvider = serviceProvider.GetRequiredService<IDurableRedisProvider>();
            var environment = serviceProvider.GetRequiredService<IWebHostEnvironment>();
            return TimeProviderFactory.CreateTimeProvider<ZonedFixedTimeProvider>(environment, new TimeConfig(), durableRedisProvider);
        });

        var provider = serviceCollection.BuildServiceProvider().GetRequiredService<TimeProvider>();
        provider.GetUtcNow();
    }
}