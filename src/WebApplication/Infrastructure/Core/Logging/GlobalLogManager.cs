using Microsoft.Extensions.Logging;

namespace Infrastructure.Core.Logging;

public static class GlobalLogManager
{
#pragma warning disable CS8618
    private static ILogger _globalLogger;
#pragma warning restore CS8618
#pragma warning disable CS8618
    private static ILoggerFactory _loggerFactory;
#pragma warning restore CS8618

    public static void SetLoggerFactory(ILoggerFactory loggerFactory, string categoryName)
    {
        _loggerFactory = loggerFactory;
        _globalLogger = loggerFactory.CreateLogger(categoryName);
    }

    public static ILogger Logger => _globalLogger;

    public static ILogger<T> GetLogger<T>() where T : class => _loggerFactory.CreateLogger<T>();
    public static ILogger GetLogger(string categoryName) => _loggerFactory.CreateLogger(categoryName);
}