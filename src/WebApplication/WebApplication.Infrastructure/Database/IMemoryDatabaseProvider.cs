using WebApplication.Application.Core.Database;
using WebApplication.Domain;

namespace WebApplication.Infrastructure.Database;

internal interface IMemoryDatabaseProvider : IMemoryDatabaseHolder
{
    void Replace(MemoryDatabase db);
    void Replace(byte[] bytes);
}