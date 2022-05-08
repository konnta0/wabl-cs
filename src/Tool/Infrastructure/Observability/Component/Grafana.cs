using Microsoft.Extensions.Logging;
using Pulumi.Kubernetes.Helm;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;

namespace Infrastructure.Observability.Component
{
    public class Grafana
    {
        private readonly ILogger<Grafana> _logger;

        public Grafana(ILogger<Grafana> logger)
        {
            _logger = logger;
        }

        public void Apply()
        {
            var grafana = new Release("grafana", new ReleaseArgs
            {
                 Chart = "grafana",
                //  helm search repo grafana/grafana --versions | head -n 10                                                                                                                                           1:11:45
                // NAME                            CHART VERSION   APP VERSION     DESCRIPTION
                // grafana/grafana                 6.28.0          8.5.0           The leading tool for querying and visualizing t...
                // grafana/grafana                 6.27.0          8.5.0           The leading tool for querying and visualizing t...
                // grafana/grafana                 6.26.8          8.5.0           The leading tool for querying and visualizing t...
                // grafana/grafana                 6.26.7          8.5.0           The leading tool for querying and visualizing t...
                // grafana/grafana                 6.26.6          8.5.0           The leading tool for querying and visualizing t...
                // grafana/grafana                 6.26.5          8.4.6           The leading tool for querying and visualizing t...
                // grafana/grafana                 6.26.4          8.4.6           The leading tool for querying and visualizing t...
                // grafana/grafana                 6.26.3          8.4.6           The leading tool for querying and visualizing t...
                // grafana/grafana                 6.26.2          8.4.6           The leading tool for querying and visualizing t...
                Version = "6.28.0",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://grafana.github.io/helm-charts"
                },
                Namespace = Define.Namespace
            }); 
        }
    }
}