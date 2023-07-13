using System.Diagnostics;

namespace Infrastructure.Core.Instrumentation.UseCase;

public class UseCaseInstrumentation : DefaultTraceListener
{ 
    private readonly UseCaseInstrumentationOptions _options;

    public UseCaseInstrumentation(UseCaseInstrumentationOptions options)
    {
        _options = options;
    }
}