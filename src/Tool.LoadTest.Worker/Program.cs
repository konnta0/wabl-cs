using DFrame;
using Microsoft.Extensions.Hosting;

var controllerAddress = Environment.GetEnvironmentVariable("CONTROLLER_ADDRESS");
if (string.IsNullOrEmpty(controllerAddress))
{
    throw new ArgumentException($"Invalid env. CONTROLLER_ADDRESS: {controllerAddress}");
}

await Host.CreateDefaultBuilder(args)
    .RunDFrameWorkerAsync(controllerAddress);