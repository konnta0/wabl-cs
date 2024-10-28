using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Tool.ManagementConsole;

public sealed class ManagementConsoleComponentInput : IComponentInput
{
    public required Namespace Namespace { get; init; }
}

public sealed class ManagementConsoleComponentOutput : IComponentOutput
{
}
