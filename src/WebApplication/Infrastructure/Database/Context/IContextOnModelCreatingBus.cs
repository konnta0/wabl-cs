using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Context;

public interface IContextOnModelCreatingBus : IReadOnlyCollection<Action<ModelBuilder>>
{
    
}