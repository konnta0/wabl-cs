using WebApplication.Application.Core.RepositoryHandler;
using WebApplication.Application.Core.RequestHandler;
using WebApplication.Application.UseCase.HealthCheck.DataTransferObject;
using WebApplication.Application.UseCase.HealthCheck.ExecutionResult;
using WebApplication.Domain.Repository.System;

namespace WebApplication.Application.UseCase.HealthCheck.Handler;

internal sealed class GetSystemInfoHandler(IUseCaseActivityStarter activityStarter, IRepositoryHandler repositoryHandler) : 
    AsyncUseCaseRequestHandlerBase<GetSystemInfoUseCaseInput, GetSystemInfoResult>(activityStarter)
{
    protected override ValueTask ValidateAsync(GetSystemInfoUseCaseInput input, CancellationToken cancellationToken = new ())
    {
        return ValueTask.CompletedTask;
    }

    protected override async ValueTask<GetSystemInfoResult> ExecuteAsync(GetSystemInfoUseCaseInput input, CancellationToken cancellationToken = new ())
    {
        var output = await repositoryHandler.InvokeAsync<IGetSystemInfoInput, IGetSystemInfoOutput>(static _ => {}, cancellationToken);

        return new GetSystemInfoResult
        {
            IsConnectedVolatileCache = output.IsConnectedVolatileCache,
            IsConnectedDurableCache = output.IsConnectedDurableCache,
            IsConnectedDatabase = output.IsConnectedDatabase
        };
    }

    protected override ValueTask<IUseCaseOutput> CollectResponseAsync(GetSystemInfoUseCaseInput input, GetSystemInfoResult executionResult,
        CancellationToken cancellationToken = new ())
    {
        var output = new GetSystemInfoUseCaseOutput
        {
            Durable = new Cache(executionResult.IsConnectedDurableCache),
            Volatile = new Cache(executionResult.IsConnectedVolatileCache),
            Database = new Database(executionResult.IsConnectedDatabase)
        };

        return new ValueTask<IUseCaseOutput>(output);
    }
}