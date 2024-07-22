using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using ConsoleAppFramework;
using MasterMemory;
using Microsoft.Extensions.Logging;
using Shared.Domain;
using Shared.Infrastructure.Database.Context;
using WebApplication.Infrastructure.Extension;
using ZLogger;

namespace Tool.DatabaseMigration.Command.Seed;

internal sealed class SeedValidateCommand(
    ILogger<SeedValidateCommand> logger,
    IDbContextHolder dbContextHolder)
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="seedPath">-s, seed directory path</param>
    /// <returns></returns>
    [Command("seed-validate")]
    public async Task<int> ValidateAsync(string seedPath = "/src/Seed")
    {
        logger.ZLogInformation("Start seed validate");
        
        var builder = new DatabaseBuilder();
        var options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() }
        };

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
                    logger.ZLogCritical($"{type} is should be apply TableAttribute");
                    continue;
                }
                
                var schemaName = tableAttribute.Name;
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
                builder.AppendDynamic(type, enumerable.ToList());
            }
        }
        
        var db = new MemoryDatabase(builder.Build());

        var validateResult = db.Validate();
        if (validateResult.IsValidationFailed)
        {
            logger.ZLogError(validateResult.FormatFailedResults());
            logger.ZLogInformation("End seed validate (failed)");
            return 1;
        }

        logger.ZLogInformation("End seed validate (succeeded)");
        return 0;
    }
}