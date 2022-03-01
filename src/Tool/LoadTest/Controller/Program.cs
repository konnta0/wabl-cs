using DFrame;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

await builder.RunDFrameControllerAsync();
