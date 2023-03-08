using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Context;

public interface IContextOnModelCreatingDispatcher
{
    void Invoke(ModelBuilder modelBuilder);
}