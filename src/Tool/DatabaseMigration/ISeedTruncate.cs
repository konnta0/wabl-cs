using Domain.Model;

namespace DatabaseMigration;

public interface ISeedTruncate
{
    Task Truncate(IModel model);
}