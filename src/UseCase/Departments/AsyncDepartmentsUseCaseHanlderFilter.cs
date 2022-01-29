using MessagePipe;
using UseCase.Core.Instrumentation;
using UseCase.Departments.List;

namespace UseCase.Departments;

[AsyncRequestHandlerFilter(typeof(AsyncListDepartmentsUseCaseHandler))]
[AsyncRequestHandlerFilter(typeof(AsyncUseCaseInstrumentationHandler<IDepartmentsInputData, IDepartmentsOutputData>), Order = -1)]
// ReSharper disable once UnusedType.Global
public partial class AsyncDepartmentsUseCaseHandler
{
}