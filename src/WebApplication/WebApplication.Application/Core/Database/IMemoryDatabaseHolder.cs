using Shared.Domain;

namespace WebApplication.Application.Core.Database;

public interface IMemoryDatabaseHolder
{
    MemoryDatabase? Db { get; }
}