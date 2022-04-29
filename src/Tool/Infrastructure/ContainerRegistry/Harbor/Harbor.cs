using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Helm;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;

namespace Infrastructure.ContainerRegistry.Harbor
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
            var harborNamespace = new Namespace("harbor", new NamespaceArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "harbor"
                }
            });
            
            var harborChart = new Chart("harbor", new ChartArgs
            {
                Chart = "harbor",
                // https://github.com/goharbor/harbor-helm/releases/tag/v1.9.0
                Version = "v1.9.0",
                FetchOptions = new ChartFetchArgs
                {
                    Repo = "https://helm.goharbor.io"
                },
                Namespace = "harbor"
            });
            harborChart.Ready();
        }
    }
}