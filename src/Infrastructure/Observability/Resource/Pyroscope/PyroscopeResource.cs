using Infrastructure.Extension;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;

namespace Infrastructure.Observability.Resource.Pyroscope
{
    public class PyroscopeResource
    {
        private readonly ILogger<PyroscopeResource> _logger;
        private readonly Config _config;

        public PyroscopeResource(ILogger<PyroscopeResource> logger, Config config)
        {
            _logger = logger;
            _config = config;
        }

        public void Apply()
        {
            var pyroscope = new Release("observability-pyroscope", new ReleaseArgs
            {
                 Chart = "pyroscope",
                // helm search repo pyroscope-io/pyroscope --versions | head -n 5
                // NAME                            CHART VERSION   APP VERSION     DESCRIPTION
                // pyroscope-io/pyroscope          0.2.66          0.29.0          A Helm chart for Pyroscope
                // pyroscope-io/pyroscope          0.2.64          0.28.1          A Helm chart for Pyroscope
                // pyroscope-io/pyroscope          0.2.62          0.28.0          A Helm chart for Pyroscope
                // pyroscope-io/pyroscope          0.2.60          0.27.0          A Helm chart for Pyroscope
                Version = "0.2.66",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://pyroscope-io.github.io/helm-chart"
                },
                Namespace = _config.GetObservabilityConfig().Namespace
            });
        }
    }
}