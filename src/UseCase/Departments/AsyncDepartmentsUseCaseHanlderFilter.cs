using MessagePipe;
using UseCase.Core;
using UseCase.Departments.List;

namespace UseCase.Departments;

[AsyncRequestHandlerFilter(typeof(AsyncUseCaseInstrumentationHandler))]
[AsyncRequestHandlerFilter(typeof(AsyncListDepartmentsUseCaseHandler))]
// ReSharper disable once UnusedType.Global
public partial class AsyncDepartmentsUseCaseHandler
{
}