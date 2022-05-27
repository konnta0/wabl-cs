using Infrastructure.Observability.Component;
using Microsoft.Extensions.Logging;
using Pulumi;

namespace Infrastructure.Observability
{
    public class ObservabilityComponent
    {
        private readonly ILogger<ObservabilityComponent> _logger;
        private readonly Grafana _grafana;
        private readonly Loki _loki;

        public ObservabilityComponent(ILogger<ObservabilityComponent> logger, Grafana grafana, Loki loki)
        {
            _logger = logger;
            _grafana = grafana;
            _loki = loki;
        }

        public void Apply()
        {
            _grafana.Apply();
            GrafanaHost = _grafana.IngressHost;
            _loki.Apply();
        }

        [Output] public Output<string> GrafanaHost { get; set; }
    }
}