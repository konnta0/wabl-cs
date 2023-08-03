using Cysharp.Text;
using Infrastructure.Cache;
using Infrastructure.Core.Instrumentation;
using Infrastructure.Core.Logging;
using Infrastructure.Database;
using Infrastructure.Extension;
using MessagePack.AspNetCoreMvcFormatter;
using MessagePack.Resolvers;
using MessagePipe;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.OpenApi.Models;
using OpenTelemetry.Logs;
using Presentation.Extension;
using UseCase.Extension;
using ZLogger;
using ZLogger.Providers;

var builder = WebApplication.CreateBuilder(args);
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

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddUseCase(builder.Configuration);
builder.Services.AddPresentation(builder.Configuration);

builder.Services.AddMvc().AddMvcOptions(options =>
{

    options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));

    // options.OutputFormatters.Clear();
    // options.InputFormatters.Clear();

    options.OutputFormatters.Add(new MessagePackOutputFormatter(ContractlessStandardResolver.Options));
    options.InputFormatters.Add(new MessagePackInputFormatter(ContractlessStandardResolver.Options));
});

builder.Services.AddMessagePipe(options =>
{
#if DEBUG
    options.EnableCaptureStackTrace = true;
#endif
    options.InstanceLifetime = InstanceLifetime.Scoped;
});


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Web Application Blueprint for C#",
        Description = "This is metric test service."
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
