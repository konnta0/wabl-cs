using System.Diagnostics;

namespace ManagementConsole.Infrastructure.Instrumentation.Repository;

public class RepositoryInstrumentation : DefaultTraceListener
{ 
    private readonly RepositoryInstrumentationOptions _options;

    public RepositoryInstrumentation(RepositoryInstrumentationOptions options)
    {
        _options = options;
    }
}