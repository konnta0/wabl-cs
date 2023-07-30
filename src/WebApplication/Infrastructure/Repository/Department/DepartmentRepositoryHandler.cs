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

internal sealed class DepartmentRepositoryHandler : RepositoryHandlerBase<IDepartmentRepositoryInput, IDepartmentRepositoryOutput>, IDepartmentRepository
{
    private readonly ILogger<DepartmentRepositoryHandler> _logger;
    private readonly EmployeesContext _employeesContext;

    public DepartmentRepositoryHandler(
        ILogger<DepartmentRepositoryHandler> logger, 
        IVolatileCacheClient cacheClient, 
        EmployeesContext employeesContext,
        IRepositoryActivityStarter activityStarter) : base(cacheClient, activityStarter)
    {
        CacheClient = cacheClient;
        _logger = logger;
        _employeesContext = employeesContext;
    }
    
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
            DepartmentsEntities = await _employeesContext.DepartmentsEntities.AsQueryable().AsNoTracking().Select(x => x).ToListAsync(cancellationToken: cancellationToken)
        };
    }

    public async Task<IAddOutput> AddAsync(IAddInput input, CancellationToken cancellationToken = new ())
    {
        await _employeesContext.DepartmentsEntities.AddAsync(new DepartmentEntity
        {
            DepotNo = input.DepotNo,
            DeptName = input.DeptName
        }, cancellationToken);
        return new AddOutput();
    }
}