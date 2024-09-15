using MessageQueue.Application.RequestHandler;
using MessageQueue.Application.UseCase.KpiLog.DataTransferObject;

namespace MessageQueue.Presentation.Worker;

internal sealed class KpiLogWorker(IServiceProvider serviceProvider) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();
        var useCaseHandler =
            scope.ServiceProvider.GetRequiredService<IUseCaseHandler>();

        _ = await useCaseHandler.InvokeAsync<AddKpiLogUseCaseInput, AddKpiLogUseCaseOutput>(new (), cancellationToken);
    }
}