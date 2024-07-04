using WebApplication.Application.Core.RequestHandler;

namespace WebApplication.Application.UseCase.HealthCheck.DataTransferObject;

public interface IGetSystemInfoUseCaseOutput : IUseCaseOutput
{
    Cache Durable { get; init; }
    Cache Volatile { get; init; }
    Database Database { get; init; }
}

public record Cache(bool IsConnected);

public record Database(bool IsConnected);