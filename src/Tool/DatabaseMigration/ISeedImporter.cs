using Domain.Entity;

namespace DatabaseMigration;

public interface ISeedImporter
{
    Task Import(IEntity entity);
}