using System.Diagnostics;

namespace ManagementConsole.Infrastructure.Instrumentation.UseCase;

public class UseCaseInstrumentation : DefaultTraceListener
{ 
    private readonly UseCaseInstrumentationOptions _options;

    public UseCaseInstrumentation(UseCaseInstrumentationOptions options)
    {
        _options = options;
    }
}