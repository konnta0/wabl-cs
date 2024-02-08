using System.Diagnostics;

namespace WebApplication.Domain.Instrumentation;

public interface IActivityStarter
{
    Activity? Start();
}