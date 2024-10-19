using System.Diagnostics;

namespace WebApplication.Infrastructure.Instrumentation.UseCase;

public class UseCaseInstrumentation(UseCaseInstrumentationOptions options) : DefaultTraceListener
{ 
    private readonly UseCaseInstrumentationOptions _options = options;
}