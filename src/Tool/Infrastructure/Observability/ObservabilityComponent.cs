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
        private readonly Tempo _tempo;

        public ObservabilityComponent(ILogger<ObservabilityComponent> logger, Grafana grafana, Loki loki, Tempo tempo)
        {
            _logger = logger;
            _grafana = grafana;
            _loki = loki;
            _tempo = tempo;
        }

        public void Apply()
        {
            _grafana.Apply();
            GrafanaHost = _grafana.IngressHost;
            _loki.Apply();
            _tempo.Apply();
        }

        [Output] public Output<string> GrafanaHost { get; set; }
    }
}