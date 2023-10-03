using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Application.Core.Database;
using Domain;
using Infrastructure.Database.Context;
using Infrastructure.Extension;
using MasterMemory;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

internal class MemoryDatabaseLoader : IMemoryDatabaseLoader
{
    private readonly IDbContextHolder _dbContextHolder;
    private readonly IMemoryDatabaseProvider _memoryDatabaseProvider;

    internal MemoryDatabaseLoader(
        IDbContextHolder dbContextHolder, 
        IMemoryDatabaseProvider memoryDatabaseProvider)
    {
        _dbContextHolder = dbContextHolder;
        _memoryDatabaseProvider = memoryDatabaseProvider;
    }

    public ValueTask Load()
    {
        var builder = new DatabaseBuilder();

        foreach (var dbContext in _dbContextHolder.GetAll())
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

                var entities = dbContext.Database.SqlQueryRaw<object>($"SELECT * FROM {schemaName}{tableName}");
                if (!entities.Any())
                {
                    continue;
                }
                
                builder.AppendDynamic(type, entities.ToList());
            }
        }
        
        _memoryDatabaseProvider.Replace(builder.Build());
        return ValueTask.CompletedTask;
    }
}