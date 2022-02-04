using Infrastructure.Repository.Departments.FindAll;
using MessagePipe;

namespace Infrastructure.Repository.Departments;

[AsyncRequestHandlerFilter(typeof(AsyncFindAllDepartmentsHandlerFilter))]
// ReSharper disable once UnusedType.Global
public partial class AsyncDepartmentsRepositoryHandler
{
}