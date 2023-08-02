using Presentation.Filter;

namespace Presentation.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPresentation(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddScoped<TransactionalFlowFilter>();
        return serviceCollection;
    }
}