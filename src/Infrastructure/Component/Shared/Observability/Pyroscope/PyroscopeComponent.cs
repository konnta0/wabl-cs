using Infrastructure.Extension;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;

namespace Infrastructure.Component.Shared.Observability.Pyroscope
{
    public class PyroscopeComponent : IComponent<PyroscopeComponentInput, PyroscopeComponentOutput>
    {
        private readonly ILogger<PyroscopeComponent> _logger;
        private readonly Config _config;

        public PyroscopeComponent(ILogger<PyroscopeComponent> logger, Config config)
        {
            _logger = logger;
            _config = config;
        }
        
        public PyroscopeComponentOutput Apply(PyroscopeComponentInput input)
        {
            var pyroscope = new Release("pyroscope", new ReleaseArgs
            {
                Name = "pyroscope",
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
                Namespace = input.Namespace.Metadata.Apply(x => x.Name)
            });
            return new PyroscopeComponentOutput();
        }
    }
}