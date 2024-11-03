using System.Diagnostics;
using MessagePipe;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace WebApplication.Infrastructure.Instrumentation.Repository;

internal class AsyncRepositoryInstrumentationHandlerFilter<TInputData, TOutputData>(
    ILogger<AsyncRepositoryInstrumentationHandlerFilter<TInputData, TOutputData>> logger)
    : AsyncRequestHandlerFilter<TInputData, TOutputData>
{
    public override async ValueTask<TOutputData> InvokeAsync(TInputData request, CancellationToken cancellationToken, Func<TInputData, CancellationToken, ValueTask<TOutputData>> next)
    {
        using var activity = RepositoryInstrumentationHelper.ActivitySource.StartActivity(
            RepositoryInstrumentationHelper.ActivityName,
            ActivityKind.Server,
            Activity.Current?.Context ?? default(ActivityContext)
        );

        activity?.SetTag("code.function", nameof(InvokeAsync));
        activity?.SetTag("InputData", request);

        TOutputData response;
        try
        {
            response = await next(request, cancellationToken);
        }
        catch (Exception e)
        {
            logger.ZLogError(e.Message);
            if (e.StackTrace != null) logger.ZLogError(e.StackTrace);
            throw;
        }

        activity?.SetTag("OutputData", response);
        return response;
    }
}