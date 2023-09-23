using System.Diagnostics;
using Infrastructure.Core.Instrumentation.UseCase;
using MessagePipe;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace Application.Core.Instrumentation;

internal class AsyncUseCaseInstrumentationHandlerFilter<TInputData, TOutputData> : AsyncRequestHandlerFilter<TInputData, TOutputData>
{
    private readonly ILogger<AsyncUseCaseInstrumentationHandlerFilter<TInputData, TOutputData>> _logger;

    public AsyncUseCaseInstrumentationHandlerFilter(
        ILogger<AsyncUseCaseInstrumentationHandlerFilter<TInputData, TOutputData>> logger)
    {
        _logger = logger;
    }

    public override async ValueTask<TOutputData> InvokeAsync(TInputData request, CancellationToken cancellationToken, Func<TInputData, CancellationToken, ValueTask<TOutputData>> next)
    {
        using var activity = UseCaseInstrumentationHelper.ActivitySource.StartActivity(
            UseCaseInstrumentationHelper.ActivityName,
            ActivityKind.Server,
            Activity.Current?.Context ?? default(ActivityContext)
        );

        activity?.SetTag("InputData", request);

        TOutputData response;
        try
        {
            response = await next(request, cancellationToken);
        }
        catch (System.Exception e)
        {
            _logger.ZLogError(e.Message);
            if (e.StackTrace != null) _logger.ZLogError(e.StackTrace);
            throw;
        }
        activity?.SetTag("OutputData", response);
        return response;
    }
}