using Shared.Domain;
using WebApplication.Application.Core.Database;

namespace WebApplication.Infrastructure.Database;

internal interface IMemoryDatabaseProvider : IMemoryDatabaseHolder
{
    void Replace(MemoryDatabase db);
    void Replace(byte[] bytes);
}