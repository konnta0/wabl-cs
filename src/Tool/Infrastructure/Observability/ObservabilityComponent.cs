using System.Collections.Immutable;
using Infrastructure.Observability.Component;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;

namespace Infrastructure.Observability
{
    public class ObservabilityComponent
    {
        private readonly ILogger<ObservabilityComponent> _logger;
        private readonly Grafana _grafana;

        public ObservabilityComponent(ILogger<ObservabilityComponent> logger, Grafana grafana)
        {
            _logger = logger;
            _grafana = grafana;
        }

        public void Apply()
        {
            _ = new Namespace(Define.Namespace, new NamespaceArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = Define.Namespace
                }
            });
            _grafana.Apply();
            GrafanaNamespace = _grafana.Namespace;
            ResourceNames = _grafana.ResourceNames;
        }

        [Output] public Output<string> GrafanaNamespace { get; set; }
        [Output] public Output<ImmutableDictionary<string, ImmutableArray<string>>> ResourceNames { get; set; }
    }
}