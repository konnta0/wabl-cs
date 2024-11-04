using WebApplication.Application.Extension;
using Cysharp.Text;
using WebApplication.Infrastructure.Extension;
using Microsoft.AspNetCore.HttpOverrides;
using OpenTelemetry.Logs;
using Shared.Infrastructure.Cache;
using Shared.Infrastructure.Database;
using Shared.Infrastructure.Logging;
using WebApplication.Infrastructure.Authentication;
using WebApplication.Infrastructure.Instrumentation;
using WebApplication.Infrastructure.Time;
using WebApplication.Presentation.BackgroundService.Extension;
using WebApplication.Presentation.Extension;
using ZLogger;
using ZLogger.Providers;

var builder =  Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);
GlobalLogManager.SetLoggerFactory(LoggerFactory.Create(loggingBuilder =>
{
    loggingBuilder.ClearProviders();
    loggingBuilder.SetMinimumLevel(LogLevel.Information);
    loggingBuilder.AddFilter<ZLoggerConsoleLoggerProvider>("Microsoft", LogLevel.None);
    loggingBuilder.AddZLoggerConsole(options =>
    {
        options.EnableStructuredLogging = true;
        var prefixFormat = ZString.PrepareUtf8<LogLevel, DateTime>("[{0}][{1}] ");
        options.PrefixFormatter = (writer, info) =>
            prefixFormat.FormatTo(ref writer, info.LogLevel, info.Timestamp.DateTime.ToLocalTime());
    });
    loggingBuilder.AddOpenTelemetry(options =>
    {
        options.IncludeScopes = true;
        options.ParseStateValues = true;
        options.IncludeFormattedMessage = true;
        options.AddInMemoryExporter(new InMemoryLogRecords());
    });
}), "Global");

builder.Configuration.Bind(nameof(DatabaseConfig),new DatabaseConfig());
builder.Configuration.Bind(nameof(InstrumentationConfig),new InstrumentationConfig());
builder.Configuration.Bind(nameof(CacheConfig),new CacheConfig());
builder.Configuration.Bind(nameof(TimeConfig),new TimeConfig());
builder.Configuration.Bind(nameof(AuthenticationConfig), new AuthenticationConfig());

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddUseCase(builder.Configuration);
builder.Services.AddPresentation(builder.Configuration);
builder.Services.AddBackgroundService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(app =>
{
    app.Run( context => context.HandleExceptionIfNeededAsync());
});

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseHttpsRedirection();
app.UseHttpLogging();
app.UseStaticFiles();
app.UseInfrastructure();

app.UseRouting();
app.UseAuthorization();
app.UseResponseCaching();
app.UseHealthChecks();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
