namespace DatabaseMigration;

public interface ISeedReader : IDisposable
{
    string Read(string path);
}