using DFrame.RestSdk;


var rootAddress = Environment.GetEnvironmentVariable("CONTROLLER_ROOT_ADDRESS");
if (string.IsNullOrEmpty(rootAddress))
{
    throw new ArgumentException($"Invalid env. CONTROLLER_ROOT_ADDRESS: {rootAddress}");
}

var workLoadName = Environment.GetEnvironmentVariable("WORKLOAD_NAME");
if (string.IsNullOrEmpty(workLoadName))
{
    throw new ArgumentException($"Invalid env. WORKLOAD_NAME: {workLoadName}");
}

var parsed = int.TryParse(Environment.GetEnvironmentVariable("CONCURRENCY"), out var concurrency);
if (!parsed)
{
    throw new ArgumentException($"Invalid env. CONCURRENCY: {concurrency}");
}

parsed = int.TryParse(Environment.GetEnvironmentVariable("TOTAL_REQUEST"), out var totalReqeust);
if (!parsed)
{
    throw new ArgumentException($"Invalid env. TOTAL_REQUEST: {totalReqeust}");
}

var client = new DFrameClient(rootAddress);

await client.ExecuteRequestAsync(new()
{
    Workload = workLoadName,
    Concurrency = concurrency,
    TotalRequest = totalReqeust
});

await client.WaitUntilCanExecute();

var result = await client.GetLatestResultAsync();