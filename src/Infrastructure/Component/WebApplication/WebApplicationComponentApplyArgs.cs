using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.WebApplication
{
    public sealed class WebApplicationComponentInput : IComponentInput
    {
        public ConfigFile OpenTelemetryCrd { get; set; } = null!;
    }

    public sealed class WebApplicationComponentOutput : IComponentOutput
    {
    }
}