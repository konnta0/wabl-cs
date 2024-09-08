using Shared.Infrastructure.Database.Context.Employee;
using WebApplication.Domain.Repository;
using WebApplication.Domain.Repository.System;
using WebApplication.Domain.Repository.System.Core;
using WebApplication.Infrastructure.Cache;
using WebApplication.Infrastructure.Core.RequestHandler;
using WebApplication.Infrastructure.Instrumentation.Repository;
using WebApplication.Infrastructure.RequestHandler;

namespace WebApplication.Infrastructure.Repository.System.Handler;

public sealed class SystemRepositoryHandler(
    IVolatileRedisProvider redisProvider, 
    IDurableRedisProvider durableRedisProvider,
    EmployeesContext employeesContext,
    IRepositoryActivityStarter activityStarter) : 
    RepositoryHandlerBase<ISystemRepositoryInput, ISystemRepositoryOutput>(redisProvider, activityStarter),
    ISystemRepository
{
    protected override async ValueTask<IRepositoryOutput?> InvokeInternalAsync(ISystemRepositoryInput input,
        CancellationToken cancellationToken = new())
    {
        return input switch
        {
            IGetSystemInfoInput getSystemInfoInput => await GetSystemInfoAsync(getSystemInfoInput, cancellationToken),
            _ => default
        };
    }

    private async ValueTask<IGetSystemInfoOutput> GetSystemInfoAsync(
        IGetSystemInfoInput input,
        CancellationToken cancellationToken = new())
    {
        var isConnectedVolatileRedis = false;
        try
        {
            await VolatileRedisProvider.String<string>("ping", defaultExpiry: TimeSpan.Zero).GetAsync();
            isConnectedVolatileRedis = true;
        }
        catch (Exception)
        {
            // ignored
        }

        var isConnectedDurableRedis = false;
        try
        {
            await durableRedisProvider.String<string>("ping").GetAsync();
            isConnectedDurableRedis = true;
        }
        catch (Exception)
        {
            // ignored
        }

        var isConnectedDatabase = false;
        try
        {
            _ = employeesContext.TitlesEntities.FirstOrDefault();
            isConnectedDatabase = true;
        }
        catch (Exception)
        {
            // ignored
        }

        return new GetSystemInfoOutput
        {
            IsConnectedDurableCache = isConnectedDurableRedis,
            IsConnectedVolatileCache = isConnectedVolatileRedis,
            IsConnectedDatabase = isConnectedDatabase
        };
    }
}