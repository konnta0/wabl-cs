using Domain.Entity.Employee;
using Domain.Repository;
using Domain.Repository.Department;
using Infrastructure.Cache;
using Infrastructure.Core.Instrumentation.Repository;
using Infrastructure.Core.RequestHandler;
using Infrastructure.Database.Context.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository.Department;

internal sealed class DepartmentRepositoryHandler(ILogger<DepartmentRepositoryHandler> logger,
        IVolatileRedisProvider redisProvider,
        EmployeesContext employeesContext,
        IRepositoryActivityStarter activityStarter)
    : RepositoryHandlerBase<IDepartmentRepositoryInput, IDepartmentRepositoryOutput>(redisProvider, activityStarter),
        IDepartmentRepository
{
    private readonly ILogger<DepartmentRepositoryHandler> _logger = logger;

    protected override async ValueTask<IRepositoryOutput?> InvokeInternalAsync(IDepartmentRepositoryInput input,
        CancellationToken cancellationToken = new ())
    {
        return input switch
        {
            IFindAllInput findAllInput => await FindAllAsync(findAllInput, cancellationToken),
            IAddInput addInput => await AddAsync(addInput, cancellationToken),
            _ => default
        };
    }

    public async Task<IFindAllOutput> FindAllAsync(IFindAllInput input, CancellationToken cancellationToken = new ())
    {
        return new FindAllOutput
        {
            DepartmentsEntities = await employeesContext.DepartmentsEntities
                .AsQueryable()
                .AsNoTracking()
                .Select(static x => x)
                .ToListAsync(cancellationToken: cancellationToken)
        };
    }

    public async Task<IAddOutput> AddAsync(IAddInput input, CancellationToken cancellationToken = new ())
    {
        await employeesContext.DepartmentsEntities.AddAsync(new DepartmentEntity
        {
            DepotNo = input.DepotNo,
            DeptName = input.DeptName
        }, cancellationToken);
        return new AddOutput();
    }
}