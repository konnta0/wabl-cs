using ManagementConsole.Application.RequestHandler;
using ManagementConsole.Application.UseCase.MemoryDatabase.DataTransferObject;
using Shared.Application.Database;

namespace ManagementConsole.Application.UseCase.MemoryDatabase.Handler;

internal class LoadMemoryDatabaseHandler(
    IUseCaseActivityStarter activityStarter,
    IMemoryDatabaseLoader memoryDatabaseLoader)
    : AsyncUseCaseRequestHandlerBase<LoadMemoryDatabaseUseCaseInput, LoadMemoryDatabaseExecuteResult>(activityStarter)
{
    protected override ValueTask ValidateAsync(LoadMemoryDatabaseUseCaseInput input,
        CancellationToken cancellationToken = new ())
    {
        return ValueTask.CompletedTask;
    }

    protected override async ValueTask<LoadMemoryDatabaseExecuteResult> ExecuteAsync(LoadMemoryDatabaseUseCaseInput input,
        CancellationToken cancellationToken = new ())
    {
        await memoryDatabaseLoader.Load();
        return new LoadMemoryDatabaseExecuteResult();
    }

    protected override ValueTask<IUseCaseOutput> CollectResponseAsync(LoadMemoryDatabaseUseCaseInput input, LoadMemoryDatabaseExecuteResult executionResult,
        CancellationToken cancellationToken = new ())
    {
        return new ValueTask<IUseCaseOutput>();
    }
}