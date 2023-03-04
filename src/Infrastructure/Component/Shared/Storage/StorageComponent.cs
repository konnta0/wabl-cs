using System.Text.Json;
using Infrastructure.Component.Shared.Storage.Dragonfly;
using Infrastructure.Component.Shared.Storage.MinIo;
using Infrastructure.Component.Shared.Storage.Redis;
using Infrastructure.Component.Shared.Storage.TiDB;
using Pulumi;

namespace Infrastructure.Component.Shared.Storage
{
    public class StorageComponent : IComponent<StorageComponentInput, StorageComponentOutput>
    {
        private readonly Config _config;
        private readonly MinIoComponent _minIoComponent;
        private readonly DragonflyComponent _dragonflyComponent;
        private readonly RedisComponent _redisComponent;
        private readonly TiDBComponent _tiDbComponent;

        public StorageComponent(Config config, 
            MinIoComponent minIoComponent, 
            DragonflyComponent dragonflyComponent, 
            RedisComponent redisComponent,
            TiDBComponent tiDbComponent)
        {
            _config = config;
            _minIoComponent = minIoComponent;
            _dragonflyComponent = dragonflyComponent;
            _redisComponent = redisComponent;
            _tiDbComponent = tiDbComponent;
        }

        public StorageComponentOutput Apply(StorageComponentInput input)
        {
            _minIoComponent.Apply(new MinIoComponentInput
            {
                Namespace = input.Namespace
            });

            var cache = _config.RequireObject<JsonElement>("Storage").GetProperty("Cache").GetString();

            switch (cache!.ToLower())
            {
                case "dragonfly":
                    _dragonflyComponent.Apply(new DragonflyComponentInput
                    {
                        Namespace = input.Namespace
                    });
                    break;
                case "redis":
                    _redisComponent.Apply(new RedisComponentInput
                    {
                        Namespace = input.Namespace
                    });
                    break;
            }
            _tiDbComponent.Apply(new TiDBComponentInput
            {
                Namespace = input.Namespace
            });
            return new StorageComponentOutput();
        }
    }
}