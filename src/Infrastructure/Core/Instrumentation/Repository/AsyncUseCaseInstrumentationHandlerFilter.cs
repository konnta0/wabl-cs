using System.Diagnostics;
using MessagePipe;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace Infrastructure.Core.Instrumentation.Repository;

internal class AsyncRepositoryInstrumentationHandlerFilter<TInputData, TOutputData> : AsyncRequestHandlerFilter<TInputData, TOutputData>
{
    private readonly ILogger<AsyncRepositoryInstrumentationHandlerFilter<TInputData, TOutputData>> _logger;

    public AsyncRepositoryInstrumentationHandlerFilter(
        ILogger<AsyncRepositoryInstrumentationHandlerFilter<TInputData, TOutputData>> logger)
    {
        _logger = logger;
    }

    public override async ValueTask<TOutputData> InvokeAsync(TInputData request, CancellationToken cancellationToken, Func<TInputData, CancellationToken, ValueTask<TOutputData>> next)
    {
        using var activity = RepositoryInstrumentationHelper.ActivitySource.StartActivity(
            RepositoryInstrumentationHelper.ActivityName,
            ActivityKind.Server,
            Activity.Current?.Context ?? default(ActivityContext)
        );

        activity?.SetTag("InputData", request);

        TOutputData response;
        try
        {
            response = await next(request, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.ZLogError(e.Message);
            if (e.StackTrace != null) _logger.ZLogError(e.StackTrace);
            throw;
        }
        activity?.SetTag("OutputData", response);
        return response;
    }
}