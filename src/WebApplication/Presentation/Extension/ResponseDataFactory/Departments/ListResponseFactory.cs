using Domain.RestApi.Departments;
using Domain.RestApi.Departments.Object;
using UseCase.Departments;

namespace Presentation.Extension.ResponseDataFactory.Departments;

internal static class ListResponseDataFactory
{
    public static ListResponse Create(ListDepartmentsUseCaseOutput useCaseOutput)
    {
        return new ListResponse
        {
            Departments =
                useCaseOutput.Departments?.Select(x => new Department { DepotNo = x.DepotNo, DeptName = x.DeptName })
        };
    }
}