using WebApplication.Application.UseCase.Departments.Dto;
using WebApplication.Domain.RestApi.HealthCheck;

namespace WebApplication.Presentation.Extension.ResponseDataFactory.HealthChecks;

internal abstract class GetSystemInfoFactory : IResponseDataFactory<GetSystemInfoResponse, GetSystemInfoUseCaseOutput>
{
    public static GetSystemInfoResponse Create(GetSystemInfoUseCaseOutput useCaseOutput)
    {
        return new GetSystemInfoResponse();
    }
}