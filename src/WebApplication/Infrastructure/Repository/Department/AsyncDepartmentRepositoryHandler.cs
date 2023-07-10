using Domain.Repository.Department;
using Infrastructure.Core.Instrumentation.Repository;
using Infrastructure.Repository.Department.FindAll;
using MessagePipe;

namespace Infrastructure.Repository.Department;

[AsyncRequestHandlerFilter(typeof(AsyncFindAllDepartmentHandlerFilter))]
[AsyncRequestHandlerFilter(typeof(AsyncRepositoryInstrumentationHandlerFilter<IDepartmentRepositoryInput, IDepartmentRepositoryOutput>), Order = -1)]
// ReSharper disable once UnusedType.Global
public partial class AsyncDepartmentRepositoryHandler
{
}