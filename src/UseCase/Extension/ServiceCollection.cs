using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UseCase.Extension;

public static class ServiceCollection
{
    public static IServiceCollection AddUseCase(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        // TODO : later
        return serviceCollection;
    }
}