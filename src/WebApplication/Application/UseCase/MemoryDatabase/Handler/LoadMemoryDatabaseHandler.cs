using Application.Core.Database;
using Application.Core.RequestHandler;
using Application.UseCase.MemoryDatabase.DataTransferObject;

namespace Application.UseCase.MemoryDatabase.Handler;

internal class LoadMemoryDatabaseHandler : AsyncUseCaseRequestHandlerBase<LoadMemoryDatabaseUseCaseInput, LoadMemoryDatabaseExecuteResult>
{
    private readonly IMemoryDatabaseLoader _memoryDatabaseLoader;
    
    public LoadMemoryDatabaseHandler(IUseCaseActivityStarter activityStarter, IMemoryDatabaseLoader memoryDatabaseLoader) : base(activityStarter)
    {
        _memoryDatabaseLoader = memoryDatabaseLoader;
    }

    protected override ValueTask ValidateAsync(LoadMemoryDatabaseUseCaseInput input,
        CancellationToken cancellationToken = new ())
    {
        return ValueTask.CompletedTask;
    }

    protected override async ValueTask<LoadMemoryDatabaseExecuteResult> ExecuteAsync(LoadMemoryDatabaseUseCaseInput input,
        CancellationToken cancellationToken = new ())
    {
        await _memoryDatabaseLoader.Load();
        return new LoadMemoryDatabaseExecuteResult();
    }

    protected override ValueTask<IUseCaseOutput> CollectResponseAsync(LoadMemoryDatabaseUseCaseInput input, LoadMemoryDatabaseExecuteResult executeResult,
        CancellationToken cancellationToken = new ())
    {
        return new ValueTask<IUseCaseOutput>();
    }
}