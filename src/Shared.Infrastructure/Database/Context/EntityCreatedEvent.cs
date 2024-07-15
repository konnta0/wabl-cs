using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain.Entity;

namespace Shared.Infrastructure.Database.Context;

public readonly struct EntityCreatedEvent
{
    public Type EntityType => _entityType;
    private readonly Type _entityType;

    public EntityTypeBuilder EntityTypeBuilder => _modelBuilder.Entity(_entityType);
    private readonly ModelBuilder _modelBuilder;

    public EntityCreatedEvent(ModelBuilder modelBuilder, Type entityType)
    {
        if (entityType.GetInterface(nameof(IHasSeed)) is null)
        {
            throw new ArgumentException($"must be implement IHasSeed. type : {entityType}");
        }
        _modelBuilder = modelBuilder;
        _entityType = entityType;
    }
}