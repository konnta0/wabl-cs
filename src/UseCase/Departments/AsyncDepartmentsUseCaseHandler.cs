using MessagePipe;
using UseCase.Core.Instrumentation;
using UseCase.Departments.List;

namespace UseCase.Departments;

[AsyncRequestHandlerFilter(typeof(AsyncListDepartmentsUseCaseHandlerFilter))]
[AsyncRequestHandlerFilter(typeof(AsyncUseCaseInstrumentationHandlerFilter<IDepartmentsInputData, IDepartmentsOutputData>), Order = -1)]
// ReSharper disable once UnusedType.Global
public partial class AsyncDepartmentsUseCaseHandler
{
}