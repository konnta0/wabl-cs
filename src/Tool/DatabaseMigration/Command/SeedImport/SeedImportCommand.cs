using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Reflection;
using System.Text.Json;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace DatabaseMigration.Command;

[Command("seed-import")]
// ReSharper disable once ClassNeverInstantiated.Global
public class SeedImportCommand : ConsoleAppBase
{
    private readonly ILogger<SeedImportCommand> _logger;
    private readonly IDbContextHolder _dbContextHolder;

    public SeedImportCommand(ILogger<SeedImportCommand> logger, IDbContextHolder dbContextHolder)
    {
        _logger = logger;
        _dbContextHolder = dbContextHolder;
    }

    [RootCommand]
    public async Task Run([Option("t", "target table")] string tableName = "",
        [Option("r", "reset table.")] bool resetTable = true,
        [Option("s", "seed directory path")] string seedPath = "/src/Seed")
    {
        _logger.ZLogInformation(Context.Timestamp.ToString(CultureInfo.InvariantCulture));
        _logger.ZLogInformationWithPayload(tableName, "Start seed import");

        foreach (var dbContext in _dbContextHolder.GetAll())
        {
            var entityTypes = dbContext.Model.GetEntityTypes()
                .Select(t => t.ClrType)
                .Where(x => x.GetInterface(nameof(IHasSeed)) is not null)
                .Where(x => x.GetInterface(nameof(IEntity)) is not null)
                .ToList();

            foreach (var type in entityTypes)
            {
                var entity = Activator.CreateInstance(type);
                if (entity is null) continue;

                if (!string.IsNullOrEmpty(tableName) && !type.Name.EndsWith(tableName)) continue;

                var tableAttribute = type.GetCustomAttribute<TableAttribute>();
                if (tableAttribute is null)
                {
                    _logger.ZLogCritical($"{type} is should be apply TableAttribute");
                    continue;
                }

                try
                {
                    var schemaName = tableAttribute.Name;
                    if (resetTable)
                    {
                        using var scope = _logger.BeginScope(schemaName);
                        _logger.ZLogInformationWithPayload(schemaName, "Truncating...");
                        await dbContext.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE `{schemaName}`");
                        _logger.ZLogInformationWithPayload(schemaName, "Truncated");
                    }

                    var path = Path.Combine(seedPath, dbContext.GetType().Name.Replace("Context", string.Empty), $"{schemaName}.json");
                    await using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

                    var concreteListType = typeof(List<>).MakeGenericType(type);
                    var deserializedObject = await JsonSerializer.DeserializeAsync(fileStream, concreteListType);
                    if (deserializedObject is null)
                    {
                        _logger.ZLogInformationWithPayload(schemaName, "Failed to load seed file");
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
                    _logger.ZLogErrorWithPayload(e, "Seed import failed");
                    throw;
                }
            }
        }
    }
}