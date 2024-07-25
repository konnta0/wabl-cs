using Shared.Application.Database;
using Shared.Domain;

namespace Shared.Infrastructure.Database;

public interface IMemoryDatabaseProvider : IMemoryDatabaseHolder
{
    void Replace(MemoryDatabase db);
    void Replace(byte[] bytes);
}