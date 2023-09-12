using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extension;

public static class DbContextExtension
{
    public static Type[] GetSeedEntityTypes(this DbContext dbContext)
    {
        return dbContext.Model.GetEntityTypes()
            .Select(t => t.ClrType)
            .Where(x => x.GetInterface(nameof(IHasSeed)) is not null)
            .Where(x => x.GetInterface(nameof(IEntity)) is not null)
            .ToArray();
    }
}