using System.Diagnostics;

namespace Infrastructure.Core.Instrumentation.Repository;

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