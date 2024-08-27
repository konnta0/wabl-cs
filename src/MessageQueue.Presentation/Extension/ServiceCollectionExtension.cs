namespace MessageQueue.Presentation.Extension;

internal static class ServiceCollectionExtension
{
    public static IServiceCollection AddPresentation(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMessageQueue();
        return serviceCollection;
    }
    
    private static IServiceCollection AddMessageQueue(this IServiceCollection services)
    {
        services.AddHostedService<Worker.KpiLogWorker>();
        return services;
    }
}