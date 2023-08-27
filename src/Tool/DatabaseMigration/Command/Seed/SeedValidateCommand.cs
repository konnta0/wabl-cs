using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using DatabaseMigration.Domain.Internal.Extension;
using Domain;
using Domain.Entity.Employee;
using Infrastructure.Database.Context;
using MasterMemory;
using MessagePack;
using MessagePack.Resolvers;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace DatabaseMigration.Command.Seed;

internal sealed class SeedValidateCommand : ConsoleAppBase
{
    private readonly ILogger<SeedValidateCommand> _logger;
    private readonly IDbContextHolder _dbContextHolder;

    public SeedValidateCommand(
        ILogger<SeedValidateCommand> logger,
        IDbContextHolder dbContextHolder)
    {
        _logger = logger;
        _dbContextHolder = dbContextHolder;
    }
    
    [Command("seed-validate")]
    public async ValueTask<int> ValidateAsync(
        [Option("s", "seed directory path")] string seedPath = "/src/Seed"
        )
    {
        _logger.ZLogInformation("Start seed validate");
        
        var builder = new DatabaseBuilder();
        var options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() }
        };

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
                    _logger.ZLogCritical($"{type} is should be apply TableAttribute");
                    continue;
                }
                
                var schemaName = tableAttribute.Name;
                var path = Path.Combine(seedPath, dbContext.GetType().Name.Replace("Context", string.Empty), $"{schemaName}.json");
                await using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

                var concreteListType = typeof(List<>).MakeGenericType(type);

                var deserializedObject = await JsonSerializer.DeserializeAsync(fileStream, concreteListType, options);
                if (deserializedObject is null)
                {
                    _logger.ZLogInformationWithPayload(schemaName, "Failed to load seed file");
                    continue;
                }

                var enumerable = (IEnumerable<object>)deserializedObject;
                builder.AppendDynamic(type, enumerable.ToList());
            }
        }
        
        var db = new MemoryDatabase(builder.Build());
        
        // Get the validate result.
        var validateResult = db.Validate();
        if (validateResult.IsValidationFailed)
        {
            // Output string format.
            _logger.ZLogError(validateResult.FormatFailedResults());
            _logger.ZLogInformation("End seed validate (failed)");
            return 1;
        }

        _logger.ZLogInformation("End seed validate (succeeded)");
        return 0;
    }
}