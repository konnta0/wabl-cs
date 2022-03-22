using Domain.RestApi.Departments;
using Domain.RestApi.Departments.Object;
using UseCase.Departments.List;

namespace Presentation.Extension.ResponseDataFactory.Departments;

internal static class ListResponseDataFactory
{
    public static ListResponseData Create(ListDepartmentsOutputData outputData)
    {
        return new ListResponseData
        {
            Departments =
                outputData.Departments?.Select(x => new Department { DepotNo = x.DepotNo, DeptName = x.DeptName })
        };
    }
}