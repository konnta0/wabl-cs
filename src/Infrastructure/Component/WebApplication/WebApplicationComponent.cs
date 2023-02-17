using Infrastructure.Component;
using Infrastructure.Component.Shared.Storage.Dragonfly;
using Infrastructure.Component.Shared.Storage.TiDB;
using Infrastructure.Component.WebApplication;
using Infrastructure.Component.WebApplication.Dotnet;
using Infrastructure.Component.WebApplication.OpenTelemetryOperator;
using Infrastructure.Component.WebApplication.Promtail;
using Infrastructure.Extension;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;

namespace Infrastructure.WebApplication
{
    public class WebApplicationComponent : IComponent<WebApplicationComponentInput, WebApplicationComponentOutput>
    {
        private readonly ILogger<WebApplicationComponent> _logger;
        private Config _config;
        private readonly DotnetApplicationComponent _dotnetApplicationComponent;
        private readonly OpenTelemetryOperatorComponent _openTelemetryOperatorComponent;
        private readonly PromtailComponent _promtailComponent;

        public WebApplicationComponent(ILogger<WebApplicationComponent> logger, Config config, 
            DotnetApplicationComponent dotnetApplicationComponent,
            OpenTelemetryOperatorComponent openTelemetryOperatorComponent,
            PromtailComponent promtailComponent)
        {
            _logger = logger;
            _config = config;
            _dotnetApplicationComponent = dotnetApplicationComponent;
            _openTelemetryOperatorComponent = openTelemetryOperatorComponent;
            _promtailComponent = promtailComponent;
        }

        public WebApplicationComponentOutput Apply(WebApplicationComponentInput input)
        {
            var @namespace = new Namespace("namespace-web-application", new NamespaceArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = _config.GetWebApplicationConfig().Namespace
                }
            });

            var openTelemetryOperatorComponentOutput = _openTelemetryOperatorComponent.Apply(new OpenTelemetryOperatorComponentInput
            {
                Namespace = @namespace
            });
            _promtailComponent.Apply(new PromtailComponentInput
            {
                Namespace = @namespace
            });
            _dotnetApplicationComponent.Apply(new DotnetApplicationComponentInput
            {
                Namespace = @namespace,
                OpenTelemetryCrd = openTelemetryOperatorComponentOutput.OpenTelemetryCrd
            });
            return new WebApplicationComponentOutput();
        }
    }
}