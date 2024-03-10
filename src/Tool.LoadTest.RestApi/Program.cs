using DFrame.RestSdk;


var mode = Environment.GetEnvironmentVariable("MODE");
if (string.IsNullOrEmpty(mode))
{
    throw new ArgumentException($"Invalid env. MODE: {mode}");
}

var rootAddress = Environment.GetEnvironmentVariable("CONTROLLER_ROOT_ADDRESS");
if (string.IsNullOrEmpty(rootAddress))
{
    throw new ArgumentException($"Invalid env. CONTROLLER_ROOT_ADDRESS: {rootAddress}");
}

var workloadName = Environment.GetEnvironmentVariable("WORKLOAD_NAME");
if (string.IsNullOrEmpty(workloadName))
{
    throw new ArgumentException($"Invalid env. WORKLOAD_NAME: {workloadName}");
}

if (!int.TryParse(Environment.GetEnvironmentVariable("CONCURRENCY"), out var concurrency))
{
    throw new ArgumentException($"Invalid env. CONCURRENCY: {concurrency}");
}

if (!int.TryParse(Environment.GetEnvironmentVariable("TOTAL_REQUEST"), out var totalRequest))
{
    throw new ArgumentException($"Invalid env. TOTAL_REQUEST: {totalRequest}");
}

var client = new DFrameClient(rootAddress);

switch (mode.ToLower())
{
    case "request":
        int? workerLimit = null;
        if (int.TryParse(Environment.GetEnvironmentVariable("WORKER_LIMIT"), out var limit))
        {
            workerLimit = limit;
        }
        
        await client.ExecuteRequestAsync(new()
        {
            Workload = workloadName,
            Concurrency = concurrency,
            TotalRequest = totalRequest,
            Workerlimit = workerLimit,
            Parameters = null
        });
        break;
    case "repeat":
        var increaseTotalRequest = 0;
        if (int.TryParse(Environment.GetEnvironmentVariable("INCREASE_TOTAL_REQUEST"), out var r))
        {
            increaseTotalRequest = r;
        }

        var increaseTotalWorker = 0;
        if (int.TryParse(Environment.GetEnvironmentVariable("INCREASE_TOTAL_WORKER"), out var w))
        {
            increaseTotalWorker = w;
        }

        await client.ExecuteRepeatAsync(new()
        {
            Workload = workloadName,
            Concurrency = concurrency,
            TotalRequest = totalRequest,
            Parameters = null,
            IncreaseTotalRequest = increaseTotalRequest,
            IncreaseTotalWorker = increaseTotalWorker,
        });
        break;
    default:
        throw new ArgumentException($"Invalid env. MODE: {mode}");
}


await client.WaitUntilCanExecute();

var result = await client.GetLatestResultAsync();
if (result is null) return;

Console.WriteLine($"TotalRequest: {result.Summary.TotalRequest}");