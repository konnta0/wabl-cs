using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Helm;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;

namespace Infrastructure.ContainerRegistry.Component
{
    public class Harbor
    {
        private readonly ILogger<Harbor> _logger;
        private Config _config;

        public Harbor(ILogger<Harbor> logger, Config config)
        {
            _logger = logger;
            _config = config;
        }

        public void Apply()
        {
            var values = new Dictionary<string, object>
            {
                ["ingress"] = new Dictionary<string, object>
                {
                    ["hosts"] = new Dictionary<string, object>
                    {
                        ["core"] = "core.harbor.domain"
                    }
                }
            };

            var harbor = new Release("harbor", new ReleaseArgs
            {
                Chart = "harbor",
                // https://github.com/goharbor/harbor-helm/releases/tag/v1.9.0
                Version = "v1.9.0",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://helm.goharbor.io"
                },
                Namespace = Define.Namespace,
                Values = values
            });
        }
    }
}