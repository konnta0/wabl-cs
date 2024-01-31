using DFrame;


var parsed = int.TryParse(Environment.GetEnvironmentVariable("PORT_WEB"), out var portWeb);
if (!parsed)
{
    throw new ArgumentException($"Invalid env. PORT_WEB: {Environment.GetEnvironmentVariable("PORT_WEB")}");
}

parsed = int.TryParse(Environment.GetEnvironmentVariable("PORT_WORKER"), out var portListenWorker);
if (!parsed)
{
    throw new ArgumentException($"Invalid env. PORT_WORKER: {Environment.GetEnvironmentVariable("PORT_WORKER")}");
}

var builder = DFrameApp.CreateBuilder(portWeb, portListenWorker);
await builder.RunControllerAsync();