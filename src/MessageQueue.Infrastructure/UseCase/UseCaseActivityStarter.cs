using System.Diagnostics;
using ManagementConsole.Application.RequestHandler;
using WebApplication.Domain.Instrumentation;

namespace ManagementConsole.Infrastructure.Instrumentation.UseCase;

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
