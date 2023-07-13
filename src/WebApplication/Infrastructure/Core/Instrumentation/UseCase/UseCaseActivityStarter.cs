using System.Diagnostics;

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
