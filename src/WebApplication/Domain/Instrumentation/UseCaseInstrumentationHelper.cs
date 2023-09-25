using System.Diagnostics;

namespace Infrastructure.Core.Instrumentation.UseCase;

public static class UseCaseInstrumentationHelper
{
    public static string ActivitySourceName => "Application";
    public static string ActivityName => ActivitySourceName + ".Execute";
    private static readonly Version? Version = typeof(UseCaseInstrumentationHelper).Assembly.GetName().Version;
    public static readonly ActivitySource ActivitySource = new (ActivitySourceName, Version?.ToString());
}