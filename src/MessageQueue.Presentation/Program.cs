using MessageQueue.Application.Extension;
using MessageQueue.Domain.Extension;
using MessageQueue.Infrastructure.Extension;
using MessageQueue.Presentation.Extension;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddDomain();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddPresentation();

var host = builder.Build();
host.Run();