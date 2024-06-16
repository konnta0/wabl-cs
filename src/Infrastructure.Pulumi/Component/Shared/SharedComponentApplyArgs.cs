using Infrastructure.Pulumi.Component.Shared.Certificate;
using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared;

public sealed class SharedComponentInput : IComponentInput
{
}

public sealed class SharedComponentOutput : IComponentOutput
{
    public required Namespace Namespace { get; init; } = null!;
    public required CertificateComponentOutput CertificateComponentOutput { get; init; } = null!;
}