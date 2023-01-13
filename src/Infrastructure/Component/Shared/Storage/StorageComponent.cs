using Infrastructure.Component.Shared.Storage.MinIo;

namespace Infrastructure.Component.Shared.Storage
{
    public class StorageComponent : IComponent<StorageComponentInput, StorageComponentOutput>
    {
        private readonly MinIoComponent _minIoComponent;

        public StorageComponent(MinIoComponent minIoComponent)
        {
            _minIoComponent = minIoComponent;
        }

        public StorageComponentOutput Apply(StorageComponentInput input)
        {
            _minIoComponent.Apply(new MinIoComponentInput
            {
                Namespace = input.Namespace
            });
            return new StorageComponentOutput();
        }
    }
}