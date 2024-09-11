using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shared.Domain.Entity.Employee;
using Shared.Infrastructure.Cache;
using Shared.Infrastructure.Database.Context.Employee;
using WebApplication.Domain.Repository;
using WebApplication.Domain.Repository.Department;
using WebApplication.Domain.Repository.Department.Core;
using WebApplication.Infrastructure.Cache;
using WebApplication.Infrastructure.Core.RequestHandler;
using WebApplication.Infrastructure.Instrumentation.Repository;
using WebApplication.Infrastructure.RequestHandler;

namespace WebApplication.Infrastructure.Repository.Department.Handler;

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