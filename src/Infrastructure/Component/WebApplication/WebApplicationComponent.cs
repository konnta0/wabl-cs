using Infrastructure.Component.Shared.Storage.Dragonfly;
using Infrastructure.Component.Shared.Storage.TiDB;
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
    public class WebApplicationComponent
    {
        private readonly ILogger<WebApplicationComponent> _logger;
        private Config _config;
        private readonly DotnetApplicationResource _dotnetApplicationResource;
        private readonly OpenTelemetryOperatorComponent _openTelemetryOperatorComponent;
        private readonly PromtailComponent _promtailComponent;

        public WebApplicationComponent(ILogger<WebApplicationComponent> logger, Config config, 
            DotnetApplicationResource dotnetApplicationResource,
            OpenTelemetryOperatorComponent openTelemetryOperatorComponent,
            PromtailComponent promtailComponent)
        {
            _logger = logger;
            _config = config;
            _dotnetApplicationResource = dotnetApplicationResource;
            _openTelemetryOperatorComponent = openTelemetryOperatorComponent;
            _promtailComponent = promtailComponent;
        }

        public string Apply()
        {
            var @namespace = new Namespace("namespace-web-application", new NamespaceArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = _config.GetWebApplicationConfig().Namespace
                }
            });

            _openTelemetryOperatorComponent.Apply(new OpenTelemetryOperatorComponentInput
            {
                Namespace = @namespace
            });
            _promtailComponent.Apply(new PromtailComponentInput
            {
                Namespace = @namespace
            });
            _dotnetApplicationResource.Apply();

            return string.Empty;
        }
    }
}