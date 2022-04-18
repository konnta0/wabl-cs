using Domain.Model;

namespace DatabaseMigration;

public class SeedImporter : ISeedImporter
{
    public void Import<TModel>(string path) where TModel : IModel
    {
        throw new NotImplementedException();
    }
}