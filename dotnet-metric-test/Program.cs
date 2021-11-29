using dotnet_metric_test.APM.Metrics.Counter;
using dotnet_metric_test.APM.Metrics.Meter;
using Microsoft.AspNetCore.HttpOverrides;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddOpenTelemetryTracing(provider =>
{
    provider.SetSampler(new AlwaysOnSampler());
    provider.AddSource("TEST_PRODUCT");
});

builder.Services.AddOpenTelemetryMetrics(providerBuilder =>
{
    providerBuilder.AddMeter(MyMeter.Name);
    providerBuilder.AddPrometheusExporter(options =>
    {
        options.StartHttpListener = true;
        options.HttpListenerPrefixes = new string[] { $"http://*:8888/" };
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
