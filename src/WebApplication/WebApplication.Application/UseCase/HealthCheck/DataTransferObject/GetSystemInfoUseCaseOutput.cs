namespace WebApplication.Application.UseCase.HealthCheck.DataTransferObject;

public sealed class GetSystemInfoUseCaseOutput : IGetSystemInfoUseCaseOutput
{
    public Cache Durable { get; init; } = new (false);
    public Cache Volatile { get; init; } = new (false);
    public Database Database { get; init; } = new(false);
}