using System.Globalization;
using DFrame;
using Microsoft.Extensions.Logging;

namespace Worker.Workload;

[Workload(nameof(ListWorkload))]
public class ListWorkload : DFrame.Workload
{
    private readonly ILogger<ListWorkload> _logger;
    private DateTime _beginTime;
    private DateTime _endTime;
    private int _executeCount;

    public ListWorkload(ILogger<ListWorkload> logger)
    {
        _logger = logger;
    }

    public override Task SetupAsync(WorkloadContext context)
    {
        _beginTime = DateTime.Now;
        _logger.LogInformation("Called Setup");
        return Task.CompletedTask;
    }

    public override async Task ExecuteAsync(WorkloadContext context)
    {
        _endTime = DateTime.Now;
        _logger.LogInformation("Execute:" + (++_executeCount));
        await Task.Delay(TimeSpan.FromSeconds(1));
    }

    public override Dictionary<string, string>? Complete(WorkloadContext context)
    {
        return new()
        {
            { "begin", _beginTime.ToString(CultureInfo.InvariantCulture) },
            { "end", _endTime.ToString(CultureInfo.InvariantCulture) },
            { "count", _executeCount.ToString() }
        };
    }
}