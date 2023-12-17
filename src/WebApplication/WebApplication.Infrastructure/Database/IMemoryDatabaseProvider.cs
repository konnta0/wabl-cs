using WebApplication.Application.Core.Database;
using Domain;

namespace WebApplication.Infrastructure.Database;

internal interface IMemoryDatabaseProvider : IMemoryDatabaseHolder
{
    void Replace(MemoryDatabase db);
    void Replace(byte[] bytes);
}