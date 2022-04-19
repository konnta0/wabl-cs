using Domain.Model;

namespace DatabaseMigration;

public interface ISeedImporter : IDisposable
{
    void Import(IModel model);
}