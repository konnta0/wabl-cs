using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using ConsoleAppFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shared.Domain.Entity;
using Shared.Infrastructure.Database.Context;
using ZLogger;

namespace Tool.DatabaseMigration.Command.Seed;

// ReSharper disable once ClassNeverInstantiated.Global
internal sealed class SeedImportCommand(
    ILogger<SeedImportCommand> logger,
    IDbContextHolder dbContextHolder)
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tableName">-t, target table</param>
    /// <param name="resetTable">-r, reset table</param>
    /// <param name="seedPath">-s, seed directory path</param>
    [Command("seed-import")]
    public async Task RunAsync(string tableName = "", bool resetTable = true, string seedPath = "/src/Seed")
    {
        logger.ZLogInformationWithPayload(tableName, "Start seed import");

        foreach (var dbContext in dbContextHolder.GetAll())
        {
            var entityTypes = dbContext.Model.GetEntityTypes()
                .Select(t => t.ClrType)
                .Where(x => x.GetInterface(nameof(IHasSeed)) is not null)
                .Where(x => x.GetInterface(nameof(IEntity)) is not null)
                .ToList();
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            };

            foreach (var type in entityTypes)
            {
                var entity = Activator.CreateInstance(type);
                if (entity is null) continue;

                if (!string.IsNullOrEmpty(tableName) && !type.Name.EndsWith(tableName)) continue;

                var tableAttribute = type.GetCustomAttribute<TableAttribute>();
                if (tableAttribute is null)
                {
                    logger.ZLogCritical($"{type} is should be apply TableAttribute");
                    continue;
                }

                try
                {
                    var schemaName = tableAttribute.Name;
                    if (resetTable)
                    {
                        using var scope = logger.BeginScope(schemaName);
                        logger.ZLogInformationWithPayload(schemaName, "Truncating...");
                        await dbContext.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE `{schemaName}`");
                        logger.ZLogInformationWithPayload(schemaName, "Truncated");
                    }

                    var path = Path.Combine(seedPath, dbContext.GetType().Name.Replace("Context", string.Empty), $"{schemaName}.json");
                    await using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

                    var concreteListType = typeof(List<>).MakeGenericType(type);
                    var deserializedObject = await JsonSerializer.DeserializeAsync(fileStream, concreteListType, options);
                    if (deserializedObject is null)
                    {
                        logger.ZLogInformationWithPayload(schemaName, "Failed to load seed file");
                        continue;
                    }

                    var enumerable = (IEnumerable<object>)deserializedObject;
                    foreach (var e in enumerable)
                    {
                        await dbContext.AddAsync(e);
                    }
                    await dbContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    logger.ZLogErrorWithPayload(e, "Seed import failed");
                    throw;
                }
            }
        }
    }
}