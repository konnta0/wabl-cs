using Microsoft.Extensions.Logging;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;

namespace Infrastructure.Observability.Resource
{
    public class Loki
    {
        private readonly ILogger<Loki> _logger;

        public Loki(ILogger<Loki> logger)
        {
            _logger = logger;
        }

        public void Apply()
        {
            var loki = new Release("loki-distributed", new ReleaseArgs
            {
                 Chart = "loki-distributed",
                // helm search repo grafana/loki-distributed --versions | head -n 5                                                                                                                                   1:02:14
                // NAME                            CHART VERSION   APP VERSION     DESCRIPTION
                // grafana/loki-distributed        0.48.3          2.5.0           Helm chart for Grafana Loki in microservices mode
                // grafana/loki-distributed        0.48.2          2.5.0           Helm chart for Grafana Loki in microservices mode
                // grafana/loki-distributed        0.48.1          2.5.0           Helm chart for Grafana Loki in microservices mode
                // grafana/loki-distributed        0.48.0          2.5.0           Helm chart for Grafana Loki in microservices mode
                Version = "0.48.3",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://grafana.github.io/helm-charts"
                },
                CreateNamespace = true,
                Namespace = Define.Namespace
            });
        }
    }
}