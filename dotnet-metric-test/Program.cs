using dotnet_metric_test.APM.Metrics.Counter;
using dotnet_metric_test.APM.Metrics.Meter;
using Microsoft.AspNetCore.HttpOverrides;
using OpenTelemetry.Exporter;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Adding the OtlpExporter creates a GrpcChannel.
// This switch must be set before creating a GrpcChannel/HttpClient when calling an insecure gRPC service.
// See: https://docs.microsoft.com/aspnet/core/grpc/troubleshoot#call-insecure-grpc-services-with-net-core-client
AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);


builder.Services.AddOpenTelemetryTracing(provider =>
{
    provider.SetResourceBuilder(ResourceBuilder.CreateDefault()
        .AddService(builder.Configuration.GetValue<string>("Otlp:ServiceName")));
    provider.AddAspNetCoreInstrumentation(options =>
    {
        options.RecordException = true;
    });
    provider.AddHttpClientInstrumentation(options =>
    {
        options.RecordException = true;
    });
    provider.AddOtlpExporter(options =>
    {
        options.Endpoint = new Uri(builder.Configuration.GetValue<string>("Otlp:Endpoint"));
    });
    provider.AddConsoleExporter();
});

builder.Services.AddOpenTelemetryMetrics(providerBuilder =>
{
    providerBuilder.SetResourceBuilder(ResourceBuilder.CreateDefault()
        .AddService(builder.Configuration.GetValue<string>("Otlp:ServiceName")));
    
    providerBuilder.AddMeter(MyMeter.Name);
    providerBuilder.AddAspNetCoreInstrumentation();
    providerBuilder.AddHttpClientInstrumentation();

    // I want to do Otlp, but Grafana Tempo doesn't support it.
    // https://grafana.com/blog/2020/11/17/tracing-with-the-grafana-cloud-agent-and-grafana-tempo/
    // providerBuilder.AddOtlpExporter(options =>
    // {
    //     options.Endpoint = new Uri(builder.Configuration.GetValue<string>("Otlp:Endpoint"));
    // });

    providerBuilder.AddPrometheusExporter(options =>
    {
        options.StartHttpListener = true;
        options.HttpListenerPrefixes = builder.Configuration.GetSection("Prometheus:Endpoints").Get<string[]>();
        options.ScrapeEndpointPath = "/metrics";
        options.ScrapeResponseCacheDurationMilliseconds = 0;
    });
});

builder.Services.AddSingleton<IMyMeter, MyMeter>();
builder.Services.AddSingleton<IMyCounter, MyCounter>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
