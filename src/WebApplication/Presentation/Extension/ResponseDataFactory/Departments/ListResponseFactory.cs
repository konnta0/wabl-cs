using WebApplication.Application.Departments.Dto;
using Domain.RestApi.Departments;
using Domain.RestApi.Departments.Object;

namespace Presentation.Extension.ResponseDataFactory.Departments;

internal static class ListResponseFactory
{
    public static ListResponse Create(ListDepartmentsUseCaseOutput useCaseOutput)
    {
        return new ListResponse
        {
            Departments =
                useCaseOutput.Departments?
                    .Select(static x => new Department { DepotNo = x.DepotNo, DeptName = x.DeptName })
        };
    }
}