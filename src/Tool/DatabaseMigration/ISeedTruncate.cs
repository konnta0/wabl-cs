using Domain.Entity;

namespace DatabaseMigration;

public interface ISeedTruncate
{
    Task Truncate(IEntity entity);
}