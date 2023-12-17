using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bogus;
using Domain.Entity.Employee;
using FluentAssertions;
using WebApplication.Infrastructure.Database.Context.Employee;
using WebApplication.Infrastructure.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared;
using Xunit;

namespace WebApplication.Test;

public sealed class TestContainersExample : TestBase
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
        await Task.Delay(new Random().Next(1000, 5000));
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