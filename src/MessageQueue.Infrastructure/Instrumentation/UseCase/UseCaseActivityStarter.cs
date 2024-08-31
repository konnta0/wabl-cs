using System.Diagnostics;
using MessageQueue.Application.RequestHandler;
using MessageQueue.Domain.Instrumentation;

namespace MessageQueue.Infrastructure.Instrumentation.UseCase;

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
