using System.Diagnostics.Metrics;
using dotnet_metric_test.Monitoring.Metrics.Meter;

namespace dotnet_metric_test.Monitoring.Metrics.Counter;

public class MyCounter : IMyCounter
{
    public Counter<double> Counter { get; init; }

    public MyCounter(IMyMeter myMeter)
    {
        Counter = myMeter.Meter.CreateCounter<double>("myCounter", description: "A counter for demonstration purpose.");
    }
}

public interface IMyCounter : ICounter<double> 
{
}

public interface ICounter<T> where T : struct  
{
    Counter<T> Counter { get; init; }
}