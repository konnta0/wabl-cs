using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Helm;
using Pulumi.Kubernetes.Helm.V3;

namespace Infrastructure.ContainerRegistry.Component
{
    public class MinIO
    {
        private readonly ILogger<MinIO> _logger;
        private Config _config;

        public MinIO(ILogger<MinIO> logger, Config config)
        {
            _logger = logger;
            _config = config;
        }

        public void Apply()
        {
            var minIOChart = new Chart("minio", new ChartArgs
            {
                Chart = "minio",
                // helm search repo minio/minio --versions
                // NAME            CHART VERSION   APP VERSION                     DESCRIPTION
                // minio/minio     4.0.0           RELEASE.2022-04-26T01-20-24Z    Multi-Cloud Object Storage
                // minio/minio     3.6.6           RELEASE.2022-04-16T04-26-02Z    Multi-Cloud Object Storage
                Version = "3.6.6",
                FetchOptions = new ChartFetchArgs
                {
                    Repo = "https://charts.min.io"
                },
                Namespace = Define.Namespace
            });
            minIOChart.Ready();
        }
    }
}