using System.Diagnostics;
using System.Text.Json;
using Infrastructure.Extension.Instrumentation;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace UseCase.Core;

internal class AsyncUseCaseInstrumentationHandler<TInputData, TOutputData> : AsyncInternalUseCaseHandler<TInputData, TOutputData> where TInputData : IInputData where TOutputData : IOutputData
{
    private readonly ILogger<AsyncUseCaseInstrumentationHandler<TInputData, TOutputData>> _logger;

    public AsyncUseCaseInstrumentationHandler(
        ILogger<AsyncUseCaseInstrumentationHandler<TInputData, TOutputData>> logger)
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