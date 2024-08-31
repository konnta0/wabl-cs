using MessageQueue.Application.UseCase.KpiLog.Handler;
using Microsoft.Extensions.DependencyInjection;

namespace MessageQueue.Application.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddUseCase();
    }
    
    private static IServiceCollection AddUseCase(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<AddKpiLogHandler>();
        return serviceCollection;
    }
}