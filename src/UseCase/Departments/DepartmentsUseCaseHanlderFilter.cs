using MessagePipe;
using UseCase.Core;
using UseCase.Departments.List;

namespace UseCase.Departments;

// ReSharper disable once UnusedType.Global
[RequestHandlerFilter(typeof(UseCaseInstrumentationHandler))]
public partial class DepartmentsUseCaseHandler
{
}