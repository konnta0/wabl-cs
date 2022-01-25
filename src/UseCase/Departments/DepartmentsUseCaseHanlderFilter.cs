using MessagePipe;
using UseCase.Core;
using UseCase.Departments.List;

namespace UseCase.Departments;

// ReSharper disable once UnusedType.Global
[RequestHandlerFilter(typeof(UseCaseInstrumentationHandler), Order = -1)]
public partial class DepartmentsUseCaseHandler
{
}