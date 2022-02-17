using System.Reflection;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace Infrastructure.Core.Interceptor;

public interface IMethodInterceptor
{ 
    void OnEnter(Type declaringType, object instance, MethodBase methodBase, object[] values);
    void OnException(Exception e);
    void OnExit();
}

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)] 
public class MethodTracerAttribute : Attribute, IMethodInterceptor
{
    private readonly ILogger<MethodTracerAttribute> _logger;

    public MethodTracerAttribute()
    {
    }
    
    public void OnEnter(Type declaringType, object instance, MethodBase methodBase, object[] values)
    {
        Console.WriteLine("OnEnter");
    }

    public void OnException(Exception e)
    {
        Console.WriteLine("OnException");
    }

    public void OnExit()
    {
        Console.WriteLine("OnExit");
    }
}