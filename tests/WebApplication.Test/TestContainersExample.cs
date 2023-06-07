using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bogus;
using Domain.Entity.Employee;
using FluentAssertions;
using Infrastructure.Database.Context.Employee;
using Infrastructure.Extension;
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
        serviceCollection.AddDbContexts(DatabaseConfig!);
        
        _serviceProvider = serviceCollection.BuildServiceProvider();
        var employeesContext = _serviceProvider!.GetRequiredService<EmployeesContext>();
        await employeesContext.Database.MigrateAsync();
        await employeesContext.Database.EnsureCreatedAsync();
    }

    [Fact]
    public async Task UseDatabaseContainer()
    {
        
        if (!bool.TryParse(Environment.GetEnvironmentVariable("TEST_ENV"), out var testEnv))
        {
            throw new Exception("TEST_ENV is null");
        }

        testEnv.Should().BeTrue();
        
        
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
    public async Task UseCacheContainer()
    {
        await Task.Delay(1);
    }
}