using System.Diagnostics;

namespace MessageQueue.Domain.Instrumentation;

public static class UseCaseInstrumentationHelper
{
    public static string ActivitySourceName => "UseCase";
    public static string ActivityName => ActivitySourceName + ".Execute";
    private static readonly Version? Version = typeof(UseCaseInstrumentationHelper).Assembly.GetName().Version;
    public static readonly ActivitySource ActivitySource = new (ActivitySourceName, Version?.ToString());
}