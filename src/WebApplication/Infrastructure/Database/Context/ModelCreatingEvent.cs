using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Context;

public struct ModelCreatingEvent<T> where T : DbContext
{
    public ModelBuilder Builder { get; init; }
}