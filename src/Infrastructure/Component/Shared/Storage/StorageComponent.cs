using Infrastructure.Component.Shared.Storage.Dragonfly;
using Infrastructure.Component.Shared.Storage.MinIo;
using Infrastructure.Component.Shared.Storage.TiDB;

namespace Infrastructure.Component.Shared.Storage
{
    public class StorageComponent : IComponent<StorageComponentInput, StorageComponentOutput>
    {
        private readonly MinIoComponent _minIoComponent;
        private readonly DragonflyComponent _dragonflyComponent;
        private readonly TiDBComponent _tiDbComponent;

        public StorageComponent(MinIoComponent minIoComponent, DragonflyComponent dragonflyComponent, TiDBComponent tiDbComponent)
        {
            _minIoComponent = minIoComponent;
            _dragonflyComponent = dragonflyComponent;
            _tiDbComponent = tiDbComponent;
        }

        public StorageComponentOutput Apply(StorageComponentInput input)
        {
            _minIoComponent.Apply(new MinIoComponentInput
            {
                Namespace = input.Namespace
            });
            _dragonflyComponent.Apply(new DragonflyComponentInput
            {
                Namespace = input.Namespace
            });
            _tiDbComponent.Apply(new TiDBComponentInput
            {
                Namespace = input.Namespace
            });
            return new StorageComponentOutput();
        }
    }
}