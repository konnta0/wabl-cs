using System.Diagnostics;

namespace WebApplication.Infrastructure.Instrumentation.Repository;

public class RepositoryInstrumentation(RepositoryInstrumentationOptions options) : DefaultTraceListener
{ 
    private readonly RepositoryInstrumentationOptions _options = options;
}