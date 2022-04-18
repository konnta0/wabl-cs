using Domain.Model;

namespace DatabaseMigration;

public interface ISeedImporter
{
    void Import<TModel>(string path) where TModel : IModel;
}