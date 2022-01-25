using System.Diagnostics;
using Infrastructure.Extension.Instrumentation;

namespace UseCase.Core;

internal class AsyncUseCaseInstrumentationHandler<TInputData, TOutputData> : AsyncInternalUseCaseHandler<TInputData, TOutputData> where TInputData : IInputData where TOutputData : IOutputData
{

    public override async ValueTask<TOutputData> InvokeAsync(TInputData request, CancellationToken cancellationToken, Func<TInputData, CancellationToken, ValueTask<TOutputData>> next)
    {
        using var _ = UseCaseInstrumentationHelper.ActivitySource.StartActivity(
            UseCaseInstrumentationHelper.ActivityName,
            ActivityKind.Client,
            Activity.Current?.Context ?? default(ActivityContext)
            // TODO :: SET Tags
        );
        
        return await next(request, cancellationToken);
    }
}