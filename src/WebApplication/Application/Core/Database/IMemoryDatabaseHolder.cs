using Domain;

namespace Application.Core.Database;

public interface IMemoryDatabaseHolder
{
    MemoryDatabase? Db { get; }
}