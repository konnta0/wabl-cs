using System.Text.Json;
using Infrastructure.Pulumi.Component.Shared.Storage.Dragonfly;
using Infrastructure.Pulumi.Component.Shared.Storage.MinIo;
using Infrastructure.Pulumi.Component.Shared.Storage.Redis;
using Infrastructure.Pulumi.Component.Shared.Storage.TiDB;
using Pulumi;

namespace Infrastructure.Pulumi.Component.Shared.Storage;

public class StorageComponent(
    Config config,
    MinIoComponent minIoComponent,
    DragonflyComponent dragonflyComponent,
    RedisComponent redisComponent,
    TiDBComponent tiDbComponent)
    : IComponent<StorageComponentInput, StorageComponentOutput>
{
    public StorageComponentOutput Apply(StorageComponentInput input)
    {
        var minIoOutput = minIoComponent.Apply(new MinIoComponentInput
        {
            Namespace = input.Namespace
        });

        var cache = config.RequireObject<JsonElement>("Storage").GetProperty("Cache").GetString();

        switch (cache!.ToLower())
        {
            case "dragonfly":
                dragonflyComponent.Apply(new DragonflyComponentInput
                {
                    Namespace = input.Namespace
                });
                break;
            case "redis":
                redisComponent.Apply(new RedisComponentInput
                {
                    Namespace = input.Namespace
                });
                break;
        }
        tiDbComponent.Apply(new TiDBComponentInput
        {
            Namespace = input.Namespace
        });

        return new StorageComponentOutput
        {
            MinIoRelease = minIoOutput.Release
        };
    }
}