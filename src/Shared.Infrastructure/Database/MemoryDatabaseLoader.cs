using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using MasterMemory;
using Microsoft.EntityFrameworkCore;
using Shared.Application.Database;
using Shared.Domain;
using Shared.Infrastructure.Database.Context;
using Shared.Infrastructure.Extension;

namespace Shared.Infrastructure.Database;

public class MemoryDatabaseLoader(
    IDbContextHolder dbContextHolder,
    IMemoryDatabaseProvider memoryDatabaseProvider)
    : IMemoryDatabaseLoader
{
    public ValueTask Load()
    {
        var builder = new DatabaseBuilder();

        foreach (var dbContext in dbContextHolder.GetAll())
        {
            var entityTypes = dbContext.GetSeedEntityTypes();
            foreach (var type in entityTypes)
            {
                var entity = Activator.CreateInstance(type);
                if (entity is null) continue;

                var tableAttribute = type.GetCustomAttribute<TableAttribute>();
                if (tableAttribute is null)
                {
                    continue;
                }

                var schemaName = tableAttribute.Schema is null ? string.Empty : tableAttribute.Schema + ".";
                var tableName = tableAttribute.Name;

                var entities = dbContext.Database.SqlQuery<object>($"SELECT * FROM {schemaName}{tableName}");
                if (!entities.Any())
                {
                    continue;
                }
                
                builder.AppendDynamic(type, entities.ToList());
            }
        }
        
        memoryDatabaseProvider.Replace(builder.Build());
        return ValueTask.CompletedTask;
    }
}