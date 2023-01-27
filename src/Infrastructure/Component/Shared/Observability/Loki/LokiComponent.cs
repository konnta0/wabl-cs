using System.Collections.Generic;
using Infrastructure.Extension;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;

namespace Infrastructure.Component.Shared.Observability.Loki
{
    public class LokiComponent : IComponent<LokiComponentInput, LokiComponentOutput>
    {
        private readonly ILogger<LokiComponent> _logger;
        private readonly Config _config;

        public LokiComponent(ILogger<LokiComponent> logger, Config config)
        {
            _logger = logger;
            _config = config;
        }
        
        public LokiComponentOutput Apply(LokiComponentInput input)
        {
            var values = new Dictionary<string, object>
            {
                
            };
            
            var loki = new Release("loki", new ReleaseArgs
            {
                Name = "loki-distributed",
                Chart = "loki-distributed",
                // helm search repo grafana/loki-distributed --versions | head -n 5
                Version = "0.58.0",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://grafana.github.io/helm-charts"
                },
                
                Values = values,
                Atomic = true,
                CreateNamespace = true,
                Namespace = input.Namespace.Metadata.Apply(x => x.Name)
            });

            return new LokiComponentOutput();
        }
    }
}