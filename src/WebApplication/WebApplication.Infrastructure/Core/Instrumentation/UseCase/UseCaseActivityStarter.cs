using System.Diagnostics;
using WebApplication.Application.Core.RequestHandler;
using WebApplication.Domain.Instrumentation;

namespace WebApplication.Infrastructure.Core.Instrumentation.UseCase;

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
