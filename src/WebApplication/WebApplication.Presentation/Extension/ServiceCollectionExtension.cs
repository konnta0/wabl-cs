using MessagePack.AspNetCoreMvcFormatter;
using MessagePack.Resolvers;
using MessagePipe;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.OpenApi.Models;
using WebApplication.Presentation.Filter;

namespace WebApplication.Presentation.Extension;

internal static class ServiceCollectionExtension
{
    public static IServiceCollection AddPresentation(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddMvc().AddMvcOptions(options =>
        {
            options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));

            // options.OutputFormatters.Clear();
            // options.InputFormatters.Clear();

            options.OutputFormatters.Add(new MessagePackOutputFormatter(ContractlessStandardResolver.Options));
            options.InputFormatters.Add(new MessagePackInputFormatter(ContractlessStandardResolver.Options));
        });

        serviceCollection.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Web Application Blueprint for C#",
                Description = "This is metric test service."
            });
        });
        
        serviceCollection.AddFilter();
        serviceCollection.AddApiVersioning();
        serviceCollection.AddVersionedApiExplorer();
        return serviceCollection;
    }
    
    private static IServiceCollection AddApiVersioning(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
        });
        return serviceCollection;
    }
    
    private static IServiceCollection AddVersionedApiExplorer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
        return serviceCollection;
    }

    private static IServiceCollection AddFilter(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllers(options =>
        {
            options.Filters.Add<TransactionalFlowFilter>();
            options.Filters.Add<ContinuousProfilerFilter>();
        });
        
        serviceCollection.AddScoped<TransactionalFlowFilter>();
        serviceCollection.AddScoped<ContinuousProfilerFilter>();
        return serviceCollection;
    }
}