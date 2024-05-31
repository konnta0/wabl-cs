using WebApplication.Application.Core.RequestHandler;

namespace WebApplication.Application.UseCase.Departments.Dto;

public interface IGetSystemInfoUseCaseOutput : IUseCaseOutput
{
    Cache Durable { get; init; }
    Cache Volatile { get; init; }
}

public record Cache(bool IsConnected);