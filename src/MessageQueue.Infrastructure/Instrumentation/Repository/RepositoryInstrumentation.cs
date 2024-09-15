using System.Diagnostics;

namespace MessageQueue.Infrastructure.Instrumentation.Repository;

public class RepositoryInstrumentation(RepositoryInstrumentationOptions options) : DefaultTraceListener
{ 
    private readonly RepositoryInstrumentationOptions _options = options;
}