using Microsoft.EntityFrameworkCore;

namespace WebApplication.Infrastructure.Database.Context;

public interface IContextOnModelCreatingDispatcher
{
    void Invoke(ModelBuilder modelBuilder);
}