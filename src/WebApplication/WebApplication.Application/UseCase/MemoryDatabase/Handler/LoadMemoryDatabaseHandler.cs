using WebApplication.Application.Core.Database;
using WebApplication.Application.Core.RequestHandler;
using WebApplication.Application.UseCase.MemoryDatabase.DataTransferObject;

namespace WebApplication.Application.UseCase.MemoryDatabase.Handler;

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

    protected override ValueTask<IUseCaseOutput> CollectResponseAsync(LoadMemoryDatabaseUseCaseInput input, LoadMemoryDatabaseExecuteResult executeResult,
        CancellationToken cancellationToken = new ())
    {
        return new ValueTask<IUseCaseOutput>();
    }
}