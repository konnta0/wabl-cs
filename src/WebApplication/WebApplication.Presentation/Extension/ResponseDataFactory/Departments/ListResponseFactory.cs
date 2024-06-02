using WebApplication.Application.Departments.Dto;
using WebApplication.Domain.RestApi.Departments;
using WebApplication.Domain.RestApi.Departments.Object;

namespace WebApplication.Presentation.Extension.ResponseDataFactory.Departments;

internal class ListResponseFactory : IResponseDataFactory<ListResponse, ListDepartmentsUseCaseOutput>
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