using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bogus;
using CloudStructures.Structures;
using Domain.Entity.Employee;
using FluentAssertions;
using Infrastructure.Cache;
using Infrastructure.Database.Context.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Extension;
using Shared;
using Xunit;

namespace WebApplication.Test;

public sealed class TestContainersExample2 : TestBase
{
    private IServiceProvider? _serviceProvider;

    protected override async Task SetUpAsync()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddLogging()
            .AddDbContexts(DatabaseConfig!)
            .AddCacheClient(CacheConfig!, out _);

        _serviceProvider = serviceCollection.BuildServiceProvider();
        var employeesContext = _serviceProvider!.GetRequiredService<EmployeesContext>();
        await employeesContext.Database.MigrateAsync();
        await employeesContext.Database.EnsureCreatedAsync();
    }

    [Fact]
    public async Task UseDatabaseContainer2()
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
    public async Task UseCacheContainer2()
    {
        const string key = "test";

        var redisProvider = _serviceProvider!.GetRequiredService<IVolatileRedisProvider>();
        var redis = redisProvider.String<string>(key, TimeSpan.FromDays(1));
        
        var keyExists = await redis.ExistsAsync();
        keyExists.Should().BeFalse();

        var setAddResult = await redis.SetAsync("value");
        setAddResult.Should().BeTrue();

        var keyExistsAfterSet = await redis.ExistsAsync();
        keyExistsAfterSet.Should().BeTrue();
    }
}