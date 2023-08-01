using Domain.RestApi.Departments;
using UseCase.Departments.Dto;

namespace Presentation.Extension.ResponseDataFactory.Departments;

public class AddResponseFactory
{
    public static AddResponse Create(AddDepartmentsUseCaseOutput useCaseOutput)
    {
        return new AddResponse
        {
        };
    }
}