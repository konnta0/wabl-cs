using MessagePipe;
using UseCase.Departments.List;

namespace UseCase.Departments;

[AsyncRequestHandlerFilter(typeof(ListDepartmentsUseCaseHandler))]
// ReSharper disable once UnusedType.Global
public partial class AsyncDepartmentsUseCaseHandler
{
}