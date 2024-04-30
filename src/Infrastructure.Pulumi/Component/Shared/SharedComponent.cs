using System.Text.Json;
using Infrastructure.Pulumi.Component.Shared.Certificate;
using Infrastructure.Pulumi.Component.Shared.CiCd;
using Infrastructure.Pulumi.Component.Shared.ContainerRegistry;
using Infrastructure.Pulumi.Component.Shared.Identity;
using Infrastructure.Pulumi.Component.Shared.Observability;
using Infrastructure.Pulumi.Component.Shared.Storage;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;

namespace Infrastructure.Pulumi.Component.Shared;

public class SharedComponent(
    Config config,
    StorageComponent storageComponent,
    CertificateComponent certificateComponent,
    CiCdComponent ciCdComponent,
    ContainerRegistryComponent containerRegistryComponent,
    ObservabilityComponent observabilityComponent,
    IdentityComponent identityComponent)
    : IComponent<SharedComponentInput, SharedComponentOutput>
{
    public SharedComponentOutput Apply(SharedComponentInput input)
    {
        var @namespace = new Namespace("namespace-shared-resource", new NamespaceArgs
        {
            Metadata = new ObjectMetaArgs
            {
                Name = "shared"
            }
        });

        var storageComponentOutput = storageComponent.Apply(new StorageComponentInput { Namespace = @namespace });
        var certificateComponentOutput =
            certificateComponent.Apply(new CertificateComponentInput { Namespace = @namespace });
        ciCdComponent.Apply(new CiCdComponentInput
        {
            Namespace = @namespace
        });
        var containerRegistryComponentOutput = containerRegistryComponent.Apply(new ContainerRegistryComponentInput
        {
            Namespace = @namespace,
            ClusterIssuer = certificateComponentOutput.ClusterIssuer
        });

        if (config.RequireObject<JsonElement>("Observability").GetProperty("Enable").GetBoolean())
        {
            observabilityComponent.Apply(new ObservabilityComponentInput
            {
                Namespace = @namespace,
                MinioRelease = storageComponentOutput.MinIoRelease
            });
        }
            
        identityComponent.Apply(new IdentityComponentInput
        {
            Namespace = @namespace
        });
            
        return new SharedComponentOutput
        {
            Namespace = @namespace
        };
    }
}