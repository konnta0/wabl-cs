using Infrastructure.Pulumi.Component.Shared.Observability.Grafana;
using Infrastructure.Pulumi.Component.Shared.Observability.Loki;
using Infrastructure.Pulumi.Component.Shared.Observability.Mimir;
using Infrastructure.Pulumi.Component.Shared.Observability.Promtail;
using Infrastructure.Pulumi.Component.Shared.Observability.Pyroscope;
using Infrastructure.Pulumi.Component.Shared.Observability.SigNoz;
using Infrastructure.Pulumi.Component.Shared.Observability.Tempo;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Pulumi.Component.Shared.Observability
{
    public class ObservabilityComponent : IComponent<ObservabilityComponentInput, ObservabilityComponentOutput>
    {
        private readonly ILogger<ObservabilityComponent> _logger;
        private readonly GrafanaComponent _grafana;
        private readonly LokiComponent _lokiComponent;
        private readonly TempoComponent _tempoComponent;
        private readonly MimirComponent _mimirComponent;
        private readonly PyroscopeComponent _pyroscopeComponent;
        private readonly PromtailComponent _promtailComponent;
        private readonly SigNozComponent _sigNozComponent;


        public ObservabilityComponent(
            ILogger<ObservabilityComponent> logger,
            GrafanaComponent grafana,
            LokiComponent lokiComponent,
            TempoComponent tempoComponent,
            MimirComponent mimirComponent,
            PyroscopeComponent pyroscopeComponent,
            PromtailComponent promtailComponent,
            SigNozComponent sigNozComponent)
        {
            _logger = logger;
            _grafana = grafana;
            _lokiComponent = lokiComponent;
            _mimirComponent = mimirComponent;
            _tempoComponent = tempoComponent;
            _pyroscopeComponent = pyroscopeComponent;
            _promtailComponent = promtailComponent;
            _sigNozComponent = sigNozComponent;
        }

        public ObservabilityComponentOutput Apply(ObservabilityComponentInput input)
        {
            _grafana.Apply(new GrafanaComponentInput { Namespace = input.Namespace });
            _lokiComponent.Apply(new LokiComponentInput { Namespace = input.Namespace });
            _tempoComponent.Apply(new TempoComponentInput
            {
                Namespace = input.Namespace,
                MinIoRelease = input.MinioRelease
            });
            _mimirComponent.Apply(new MimirComponentInput { Namespace = input.Namespace });
            _pyroscopeComponent.Apply(new PyroscopeComponentInput { Namespace = input.Namespace });
            _promtailComponent.Apply(new PromtailComponentInput { Namespace = input.Namespace });

            _sigNozComponent.Apply(new SigNozComponentInput { Namespace = input.Namespace });
            return new ObservabilityComponentOutput();
        }
    }
}