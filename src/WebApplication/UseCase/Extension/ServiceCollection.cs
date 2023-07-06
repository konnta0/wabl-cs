using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UseCase.Core.RequestHandler;
using UseCase.Departments;

namespace UseCase.Extension;

public static class ServiceCollection
{
    public static IServiceCollection AddUseCase(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {

        serviceCollection
                    .AddScoped<IAsyncUseCaseHandler<IDepartmentsInputData, IDepartmentsOutputData>, AsyncDepartmentsUseCaseHandler>();
        return serviceCollection;
    }
}