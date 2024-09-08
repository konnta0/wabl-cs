using System.Diagnostics;
using WebApplication.Domain.Instrumentation;
using MessagePipe;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace WebApplication.Application.Core.Instrumentation;

internal class AsyncApplicationInstrumentationHandlerFilter<TInputData, TOutputData>(
    ILogger<AsyncApplicationInstrumentationHandlerFilter<TInputData, TOutputData>> logger)
    : AsyncRequestHandlerFilter<TInputData, TOutputData>
{
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
            logger.ZLogError(e.Message);
            if (e.StackTrace != null) logger.ZLogError(e.StackTrace);
            throw;
        }
        activity?.SetTag("OutputData", response);
        return response;
    }
}