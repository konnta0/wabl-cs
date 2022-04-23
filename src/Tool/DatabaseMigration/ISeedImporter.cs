using Domain.Entity;

namespace DatabaseMigration;

public interface ISeedImporter : IDisposable
{
    void Import(IEntity entity);
}