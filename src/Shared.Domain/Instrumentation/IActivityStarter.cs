using System.Diagnostics;

namespace Shared.Domain.Instrumentation;

public interface IActivityStarter
{
    Activity? Start();
}