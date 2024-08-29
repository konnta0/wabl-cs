using System.Diagnostics;

namespace ManagementConsole.Infrastructure.Instrumentation.Repository;

public class RepositoryActivityStarter : IRepositoryActivityStarter
{
    public Activity? Start()
    {
        return RepositoryInstrumentationHelper.ActivitySource.StartActivity(
            RepositoryInstrumentationHelper.ActivityName,
            ActivityKind.Server,
            Activity.Current?.Context ?? default(ActivityContext)
        );
    }
}