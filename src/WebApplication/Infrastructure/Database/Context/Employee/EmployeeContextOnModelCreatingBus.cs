using Domain.Entity.Employee;
using MessagePipe;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Database.Context.Employee;

public class EmployeesContextOnModelCreatingBus : IDisposable
{
    private readonly ILogger<EmployeesContextOnModelCreatingBus> _logger;
    IDisposable _subscription;

    private readonly IPublisher<EntityCreatedEvent> _entityCreatedEvent;

    public EmployeesContextOnModelCreatingBus(ILogger<EmployeesContextOnModelCreatingBus> logger, ISubscriber<ModelCreatingEvent<EmployeesContext>> subscriber, IPublisher<EntityCreatedEvent> entityCreatedEvent)
    {
        _logger = logger;
        _entityCreatedEvent = entityCreatedEvent;
        _subscription = DisposableBag.Create(subscriber.Subscribe(Create));
    }

    internal void Create(ModelCreatingEvent<EmployeesContext> modelCreatingEvent)
    {
        var builder = modelCreatingEvent.Builder;
        DepartmentEntity.OnModelCreating(builder.Entity<DepartmentEntity>());
        _entityCreatedEvent.Publish(new EntityCreatedEvent(builder, typeof(DepartmentEntity)));
        DeptEmpEntity.OnModelCreating(builder.Entity<DeptEmpEntity>());
        EmployeesEntity.OnModelCreating(builder.Entity<EmployeesEntity>());
        SalariesEntity.OnModelCreating(builder.Entity<SalariesEntity>());
        TitlesEntity.OnModelCreating(builder.Entity<TitlesEntity>());
    }

    public void Dispose()
    {
        _subscription.Dispose();
    }
}