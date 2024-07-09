namespace WebApplication.Domain.Repository.Department.Core;

public interface IDepartmentRepository : IRepository
{
    Task<IFindAllOutput> FindAllAsync(IFindAllInput input, CancellationToken cancellationToken = new CancellationToken());
    Task<IAddOutput> AddAsync(IAddInput input, CancellationToken cancellationToken = new CancellationToken());
}