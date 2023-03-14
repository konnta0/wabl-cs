namespace DatabaseMigration;

public interface ISeedReader
{
    Task<string> Read(string path);
}