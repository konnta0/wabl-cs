using Infrastructure.Observability.Resource;
using Infrastructure.Observability.Resource.Grafana;
using Infrastructure.Observability.Resource.Loki;
using Infrastructure.Observability.Resource.Tempo;
using Microsoft.Extensions.Logging;
using Pulumi;

namespace Infrastructure.Observability
{
    public class ObservabilityComponent
    {
        private readonly ILogger<ObservabilityComponent> _logger;
        private readonly GrafanaResource _grafana;
        private readonly LokiResource _lokiResource;
        private readonly TempoResource _tempoResource;

        public ObservabilityComponent(ILogger<ObservabilityComponent> logger, GrafanaResource grafana, LokiResource lokiResource, TempoResource tempoResource)
        {
            _logger = logger;
            _grafana = grafana;
            _lokiResource = lokiResource;
            _tempoResource = tempoResource;
        }

        public Output<string> Apply()
        {
            var grafanaHost = _grafana.Apply();
            _lokiResource.Apply();
            _tempoResource.Apply();
            return grafanaHost;
        }
    }
}