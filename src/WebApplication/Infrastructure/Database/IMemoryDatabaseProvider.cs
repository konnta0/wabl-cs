using Application.Core.Database;
using Domain;

namespace Infrastructure.Database;

internal interface IMemoryDatabaseProvider : IMemoryDatabaseHolder
{
    void Replace(MemoryDatabase db);
    void Replace(byte[] bytes);
}