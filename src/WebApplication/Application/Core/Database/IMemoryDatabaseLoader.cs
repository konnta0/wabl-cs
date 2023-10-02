namespace Application.Core.Database;

public interface IMemoryDatabaseLoader
{
    public ValueTask Load();
}