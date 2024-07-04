using WebApplication.Application.UseCase.Departments.DataTransferObject;
using WebApplication.Domain.RestApi.Departments;

namespace WebApplication.Presentation.Extension.ResponseDataFactory.Departments;

internal class AddResponseFactory : IResponseDataFactory<AddResponse, AddDepartmentsUseCaseOutput>
{
    public static AddResponse Create(AddDepartmentsUseCaseOutput useCaseOutput)
    {
        return new AddResponse
        {
        };
    }
}

