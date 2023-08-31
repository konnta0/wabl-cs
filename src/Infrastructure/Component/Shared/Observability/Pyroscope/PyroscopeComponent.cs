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
                // helm search repo grafana/pyroscope --versions | head -n 5
                Version = "1.0.1",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://grafana.github.io/helm-charts"
                },
                Namespace = input.Namespace.Metadata.Apply(x => x.Name)
            });
            return new PyroscopeComponentOutput();
        }
    }
}