namespace Infrastructure.Component.Shared.ContainerRegistry
{
    public struct ContainerRegistryConfig
    {
        public HarborConfig Harbor { get; set; }
        public MinIOConfig MinIO { get; set; }

        public struct HarborConfig
        {
            public NodeSelector NodeSelector { get; set; }
        }

        public struct MinIOConfig
        {
            public NodeSelector NodeSelector { get; set; }
        }
        
        public string Host { get; set; }
    }
}