using WebApplication.Application.Core.RequestHandler;

namespace WebApplication.Application.UseCase.HealthCheck.ExecutionResult;

internal sealed class GetSystemInfoResult : IUseCaseExecuteResult
{
    public required bool IsConnectedVolatileCache { get; init; }
    public required bool IsConnectedDurableCache { get; init; }
    public required bool IsConnectedDatabase { get; init; }
}