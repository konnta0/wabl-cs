namespace Domain.Repository.Department;

public interface IFindAllInput : IDepartmentRepositoryInput, ICacheableRepositoryInput
{
    TimeSpan ICacheableRepositoryInput.CacheExpiry => TimeSpan.FromMinutes(5);
    string ICacheableRepositoryInput.CacheKey => "Department.FindAll";
}