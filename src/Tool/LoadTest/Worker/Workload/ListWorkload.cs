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
    private readonly HttpClient _client;

    public ListWorkload(ILogger<ListWorkload> logger)
    {
        _logger = logger;
        var controllerBaseAddress = Environment.GetEnvironmentVariable("APPLICATION_BASE_ADDRESS");
        if (string.IsNullOrEmpty(controllerBaseAddress))
        {
            throw new ArgumentException("invalid environment APPLICATION_BASE_ADDRESS");
        }
        _client = new HttpClient { BaseAddress = new Uri(controllerBaseAddress)};
    }

    public override Task SetupAsync(WorkloadContext context)
    {
        _beginTime = DateTime.Now;

        return Task.CompletedTask;
    }

    public override async Task ExecuteAsync(WorkloadContext context)
    {
        _endTime = DateTime.Now;
        ++_executeCount;
        await _client.GetAsync("/api/health-check/ping");
        await _client.GetAsync("/api/departments/list");
    }

    public override Dictionary<string, string>? Complete(WorkloadContext context)
    {
        _client.Dispose();
        return new()
        {
            { "begin", _beginTime.ToString(CultureInfo.InvariantCulture) },
            { "end", _endTime.ToString(CultureInfo.InvariantCulture) },
            { "count", _executeCount.ToString() }
        };
    }
}