using System.Diagnostics;

namespace WebApplication.Infrastructure.Instrumentation.Repository;

public class RepositoryInstrumentation : DefaultTraceListener
{ 
    private readonly RepositoryInstrumentationOptions _options;

    public RepositoryInstrumentation(RepositoryInstrumentationOptions options)
    {
        _options = options;
    }
}