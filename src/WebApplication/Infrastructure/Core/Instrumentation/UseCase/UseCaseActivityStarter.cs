using System.Diagnostics;
using Application.Core.RequestHandler;
using Domain.Instrumentation;

namespace Infrastructure.Core.Instrumentation.UseCase;

public sealed class UseCaseActivityStarter : IUseCaseActivityStarter
{
    public Activity? Start()
    {
        return UseCaseInstrumentationHelper.ActivitySource.StartActivity(
            UseCaseInstrumentationHelper.ActivityName,
            ActivityKind.Server,
            Activity.Current?.Context ?? default(ActivityContext)
        );
    }
}
