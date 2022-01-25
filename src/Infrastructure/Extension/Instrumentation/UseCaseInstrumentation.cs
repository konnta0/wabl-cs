using System.Diagnostics;

namespace Infrastructure.Extension.Instrumentation;

public class UseCaseInstrumentation : DefaultTraceListener
{ 
    private readonly UseCaseInstrumentationOptions _options;

    public UseCaseInstrumentation(UseCaseInstrumentationOptions options)
    {
        _options = options;
    }
}