using Infrastructure.Component.Shared.Storage.Dragonfly;
using Infrastructure.Component.Shared.Storage.MinIo;

namespace Infrastructure.Component.Shared.Storage
{
    public class StorageComponent : IComponent<StorageComponentInput, StorageComponentOutput>
    {
        private readonly MinIoComponent _minIoComponent;
        private readonly DragonflyComponent _dragonflyComponent;

        public StorageComponent(MinIoComponent minIoComponent, DragonflyComponent dragonflyComponent)
        {
            _minIoComponent = minIoComponent;
            _dragonflyComponent = dragonflyComponent;
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
            return new StorageComponentOutput();
        }
    }
}