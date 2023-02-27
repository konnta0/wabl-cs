using Domain.Entity.Employee;
using MessagePipe;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Database.Context.Employee;

public partial class EmployeesContext : DbContext
{
    private readonly IPublisher<ModelCreatingEvent<EmployeesContext>> _publisher;

    public EmployeesContext(DbContextOptions<EmployeesContext> dbContextOptions, IPublisher<ModelCreatingEvent<EmployeesContext>> publisher) : base(dbContextOptions)
    {
        _publisher = publisher;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _publisher.Publish(new ModelCreatingEvent<EmployeesContext>{Builder = modelBuilder});
    }

    public static string GetConnectionString()
    {
        var server = Environment.GetEnvironmentVariable("DB_SERVER_HOST");
        var port = Environment.GetEnvironmentVariable("DB_SERVER_PORT");
        var user = Environment.GetEnvironmentVariable("DB_SERVER_USER");
        var password = Environment.GetEnvironmentVariable("DB_SERVER_PASSWORD");
        return $"server={server};port={port};user={user};password={password};Database=employees";
    }
}