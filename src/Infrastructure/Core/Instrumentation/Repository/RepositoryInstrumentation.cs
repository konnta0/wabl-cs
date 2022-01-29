using System.Diagnostics;
using Infrastructure.Extension.Instrumentation;

namespace Infrastructure.Core.Instrumentation.Repository;

public class RepositoryInstrumentation : DefaultTraceListener
{ 
    private readonly RepositoryInstrumentationOptions _options;

    public RepositoryInstrumentation(RepositoryInstrumentationOptions options)
    {
        _options = options;
    }
}