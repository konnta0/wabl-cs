namespace Shared.Application.Database;

public interface IMemoryDatabaseLoader
{
    public ValueTask Load();
}