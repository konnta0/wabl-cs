using DFrame;
using Microsoft.Extensions.Hosting;

await Host.CreateDefaultBuilder(args)
    .RunDFrameWorkerAsync("http://localhost:7313");