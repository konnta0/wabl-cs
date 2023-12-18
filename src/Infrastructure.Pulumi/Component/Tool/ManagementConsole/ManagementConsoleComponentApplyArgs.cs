using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Tool.ManagementConsole;

public sealed class ManagementConsoleComponentInput : IComponentInput
{
    public Namespace Namespace { get; set; } = null!;
}

public sealed class ManagementConsoleComponentOutput : IComponentOutput
{
}
