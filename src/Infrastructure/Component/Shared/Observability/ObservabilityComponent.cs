using Infrastructure.Component.Shared.Observability.Grafana;
using Infrastructure.Component.Shared.Observability.Loki;
using Infrastructure.Component.Shared.Observability.Mimir;
using Infrastructure.Component.Shared.Observability.MinIO;
using Infrastructure.Component.Shared.Observability.Pyroscope;
using Infrastructure.Component.Shared.Observability.Tempo;
using Microsoft.Extensions.Logging;
using Pulumi;

namespace Infrastructure.Resource.Shared.Observability
{
    public class ObservabilityComponent
    {
        private readonly ILogger<ObservabilityComponent> _logger;
        private readonly GrafanaResource _grafana;
        private readonly LokiResource _lokiResource;
        private readonly TempoResource _tempoResource;
        private readonly MimirResource _mimirResource;
        private readonly PyroscopeResource _pyroscopeResource;
        private readonly MinIOResource _minIoResource;

        public ObservabilityComponent(
            ILogger<ObservabilityComponent> logger,
            GrafanaResource grafana,
            LokiResource lokiResource,
            TempoResource tempoResource,
            MimirResource mimirResource,
            PyroscopeResource pyroscopeResource,
            MinIOResource minIoResource)
        {
            _logger = logger;
            _grafana = grafana;
            _lokiResource = lokiResource;
            _mimirResource = mimirResource;
            _tempoResource = tempoResource;
            _pyroscopeResource = pyroscopeResource;
            _minIoResource = minIoResource;
        }

        public Output<string> Apply()
        {
            _minIoResource.Apply();
            var grafanaHost = _grafana.Apply();
            _lokiResource.Apply();
            _tempoResource.Apply();
            _mimirResource.Apply();
            _pyroscopeResource.Apply();
            return grafanaHost;
        }
    }
}