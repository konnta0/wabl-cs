using Shared.Domain;

namespace Shared.Infrastructure.Database;

public class MemoryDatabaseProvider : IMemoryDatabaseProvider
{
    public MemoryDatabase? Db => _db;
    private MemoryDatabase? _db;

    public void Replace(MemoryDatabase db)
    {
        Interlocked.Exchange(ref _db, db);
    }

    public void Replace(byte[] bytes)
    {
        Replace(new MemoryDatabase(bytes));
    }
}