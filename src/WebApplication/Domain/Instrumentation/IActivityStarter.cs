using System.Diagnostics;

namespace Domain.Instrumentation;

public interface IActivityStarter
{
    Activity? Start();
}