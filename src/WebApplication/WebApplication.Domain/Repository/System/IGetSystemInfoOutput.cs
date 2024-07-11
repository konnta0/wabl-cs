using WebApplication.Domain.Repository.System.Core;

namespace WebApplication.Domain.Repository.System;

public interface IGetSystemInfoOutput : ISystemRepositoryOutput
{
     bool IsConnectedVolatileCache { get; init; }
     bool IsConnectedDurableCache { get; init; }
     bool IsConnectedDatabase { get; init; }
}