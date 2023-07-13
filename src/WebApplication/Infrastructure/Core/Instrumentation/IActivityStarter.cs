using System.Diagnostics;

namespace Infrastructure.Core.Instrumentation;

public interface IActivityStarter
{
    Activity? Start();
}