using System.Diagnostics;

namespace WebApplication.Infrastructure.Core.Instrumentation.Repository;

public class RepositoryInstrumentationHelper
{
    public static string ActivitySourceName => "Repository";
    public static string ActivityName => ActivitySourceName + ".Execute";
    private static readonly Version? Version = typeof(RepositoryInstrumentationHelper).Assembly.GetName().Version;
    public static readonly ActivitySource ActivitySource = new (ActivitySourceName, Version?.ToString());
}