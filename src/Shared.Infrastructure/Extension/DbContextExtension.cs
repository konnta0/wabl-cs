using Microsoft.EntityFrameworkCore;
using Shared.Domain.Entity;

namespace Shared.Infrastructure.Extension;

public static class DbContextExtension
{
    public static Type[] GetSeedEntityTypes(this DbContext dbContext)
    {
        return dbContext.Model.GetEntityTypes()
            .Select(static t => t.ClrType)
            .Where(static x => x.GetInterface(nameof(IHasSeed)) is not null)
            .Where(static x => x.GetInterface(nameof(IEntity)) is not null)
            .ToArray();
    }
}