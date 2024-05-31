namespace WebApplication.Application.UseCase.Departments.Dto;

public sealed class GetSystemInfoUseCaseOutput : IGetSystemInfoUseCaseOutput
{
    public Cache Durable { get; init; } = new Cache(false);
    public Cache Volatile { get; init; } = new Cache(false);
}