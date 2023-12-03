using WebApplication.Application.Departments.Dto;
using WebApplication.Application.UseCase.Departments.Dto;
using Domain.RestApi.Departments;

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