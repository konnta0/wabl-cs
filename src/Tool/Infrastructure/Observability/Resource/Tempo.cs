using Microsoft.Extensions.Logging;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;

namespace Infrastructure.Observability.Resource
{
    public class Tempo
    {
        private readonly ILogger<Tempo> _logger;

        public Tempo(ILogger<Tempo> logger)
        {
            _logger = logger;
        }

        public void Apply()
        {
            var tempo = new Release("tempo-distributed", new ReleaseArgs
            {
                Chart = "tempo-distributed",
                // helm search repo grafana/tempo-distributed --versions | head -n 5
                // NAME                            CHART VERSION   APP VERSION     DESCRIPTION
                // grafana/tempo-distributed       0.19.0          1.4.1           Grafana Tempo in MicroService mode
                // grafana/tempo-distributed       0.18.2          1.4.1           Grafana Tempo in MicroService mode
                // grafana/tempo-distributed       0.18.1          1.4.1           Grafana Tempo in MicroService mode
                // grafana/tempo-distributed       0.18.0          1.4.1           Grafana Tempo in MicroService mode
                Version = "0.19.0",
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