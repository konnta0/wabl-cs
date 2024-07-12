namespace WebApplication.Application.UseCase.HealthCheck.DataTransferObject;

public sealed class GetSystemInfoUseCaseOutput : IGetSystemInfoUseCaseOutput
{
    public required Cache Durable { get; init; } = new (false);
    public required Cache Volatile { get; init; } = new (false);
    public required Database Database { get; init; } = new(false);
}