using Shared.Domain;

namespace Shared.Application.Database;

public interface IMemoryDatabaseHolder
{
    MemoryDatabase? Db { get; }
}