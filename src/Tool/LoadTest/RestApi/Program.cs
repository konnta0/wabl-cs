using DFrame.RestSdk;


var rootAddress = Environment.GetEnvironmentVariable("CONTROLLER_ROOT_ADDRESS");
if (string.IsNullOrEmpty(rootAddress))
{
    throw new ArgumentException($"Invalid env. CONTROLLER_ROOT_ADDRESS: {rootAddress}");
}

var client = new DFrameClient(rootAddress);

await client.ExecuteRequestAsync(new()
{
    Workload = "ListWorkload",
    Concurrency = 10,
    TotalRequest = 100000
});

await client.WaitUntilCanExecute();

var result = await client.GetLatestResultAsync();