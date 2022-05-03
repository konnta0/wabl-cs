using Domain.Repository.Department;
using Infrastructure.Core.Instrumentation.Repository;
using Infrastructure.Repository.Department.FindAll;
using MessagePipe;

namespace Infrastructure.Repository.Departments;

[AsyncRequestHandlerFilter(typeof(AsyncFindAllDepartmentHandlerFilter))]
[AsyncRequestHandlerFilter(typeof(AsyncRepositoryInstrumentationHandlerFilter<IDepartmentRepositoryInputData, IDepartmentRepositoryOutputData>), Order = -1)]
// ReSharper disable once UnusedType.Global
public partial class AsyncDepartmentRepositoryHandler
{
}