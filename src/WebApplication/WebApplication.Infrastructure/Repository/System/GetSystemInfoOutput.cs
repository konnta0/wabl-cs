using WebApplication.Domain.Repository.System;

namespace WebApplication.Infrastructure.Repository.System;

public sealed class GetSystemInfoOutput : IGetSystemInfoOutput
{
    public required bool IsConnectedVolatileCache { get; init; }
    public required bool IsConnectedDurableCache { get; init; }
    public required bool IsConnectedDatabase { get; init; }
}