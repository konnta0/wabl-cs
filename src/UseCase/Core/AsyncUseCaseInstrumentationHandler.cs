using System.Diagnostics;
using System.Text.Json;
using Infrastructure.Extension.Instrumentation;

namespace UseCase.Core;

internal class AsyncUseCaseInstrumentationHandler<TInputData, TOutputData> : AsyncInternalUseCaseHandler<TInputData, TOutputData> where TInputData : IInputData where TOutputData : IOutputData
{

    public override async ValueTask<TOutputData> InvokeAsync(TInputData request, CancellationToken cancellationToken, Func<TInputData, CancellationToken, ValueTask<TOutputData>> next)
    {
        using var activity = UseCaseInstrumentationHelper.ActivitySource.StartActivity(
            UseCaseInstrumentationHelper.ActivityName,
            ActivityKind.Client,
            Activity.Current?.Context ?? default(ActivityContext)
        );

        var response = await next(request, cancellationToken);
        if (activity is not null)
        {
            activity.SetTag("InputData", request);
            activity.SetTag("OutputData", response);
        }
        return response;
    }
}