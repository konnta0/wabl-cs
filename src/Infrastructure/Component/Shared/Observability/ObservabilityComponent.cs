using Infrastructure.Component.Shared.Observability.Grafana;
using Infrastructure.Component.Shared.Observability.Loki;
using Infrastructure.Component.Shared.Observability.Mimir;
using Infrastructure.Component.Shared.Observability.MinIO;
using Infrastructure.Component.Shared.Observability.Pyroscope;
using Infrastructure.Component.Shared.Observability.Tempo;
using Microsoft.Extensions.Logging;
using Pulumi;

namespace Infrastructure.Component.Shared.Observability
{
    public class ObservabilityComponent : IComponent<ObservabilityComponentInput, ObservabilityComponentOutput>
    {
        private readonly ILogger<ObservabilityComponent> _logger;
        private readonly GrafanaComponent _grafana;
        private readonly LokiComponent _lokiComponent;
        private readonly TempoComponent _tempoComponent;
        private readonly MimirComponent _mimirComponent;
        private readonly PyroscopeComponent _pyroscopeComponent;
        private readonly MinIoComponent _minIoComponent;

        public ObservabilityComponent(
            ILogger<ObservabilityComponent> logger,
            GrafanaComponent grafana,
            LokiComponent lokiComponent,
            TempoComponent tempoComponent,
            MimirComponent mimirComponent,
            PyroscopeComponent pyroscopeComponent,
            MinIoComponent minIoComponent)
        {
            _logger = logger;
            _grafana = grafana;
            _lokiComponent = lokiComponent;
            _mimirComponent = mimirComponent;
            _tempoComponent = tempoComponent;
            _pyroscopeComponent = pyroscopeComponent;
            _minIoComponent = minIoComponent;
        }

        public ObservabilityComponentOutput Apply(ObservabilityComponentInput input)
        {
            _grafana.Apply(new GrafanaComponentInput { Namespace = input.Namespace });
            _lokiComponent.Apply(new LokiComponentInput {Namespace = input.Namespace});
            _tempoComponent.Apply();
            _mimirComponent.Apply();
            _pyroscopeComponent.Apply();
            return new ObservabilityComponentOutput();
        }
    }
}