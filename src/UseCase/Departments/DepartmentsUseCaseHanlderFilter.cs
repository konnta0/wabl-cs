using MessagePipe;
using UseCase.Departments.List;

namespace UseCase.Departments;

[RequestHandlerFilter(typeof(FindDepartmentsHandler))]
[RequestHandlerFilter(typeof(FindManyDepartmentsHandler))]
[RequestHandlerFilter(typeof(ListDepartmentsUseCaseHandler))]
// ReSharper disable once UnusedType.Global
public partial class DepartmentsUseCaseHandler
{
}