using System.Diagnostics;

namespace ManagementConsole.Infrastructure.Instrumentation.Repository;

public class RepositoryInstrumentationHelper
{
    private static string ActivitySourceName => "Repository";
    public static string ActivityName => ActivitySourceName + ".Execute";
    private static readonly Version? Version = typeof(RepositoryInstrumentationHelper).Assembly.GetName().Version;
    public static readonly ActivitySource ActivitySource = new (ActivitySourceName, Version?.ToString());
}