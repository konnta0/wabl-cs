namespace dotnet_metric_test.Monitoring.Metrics.Meter;

public class MyMeter : IMyMeter
{
    public static readonly string Name = "MyMeter"; 
    public System.Diagnostics.Metrics.Meter Meter { get; init; }

    public MyMeter()
    {
        Meter = new System.Diagnostics.Metrics.Meter(Name);
    }
}


public interface IMyMeter : IMeter
{
}

public interface IMeter
{
    System.Diagnostics.Metrics.Meter Meter { get; init; }
}