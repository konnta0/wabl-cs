namespace Infrastructure.Pulumi.Component.Shared.ContainerRegistry
{
    public struct ContainerRegistryConfig
    {
        public HarborConfig Harbor { get; init; }

        public struct HarborConfig
        {
            public bool Deploy { get; init; }
            public NodeSelector NodeSelector { get; init; }
        }

        public string Host { get; init; }
    }
}