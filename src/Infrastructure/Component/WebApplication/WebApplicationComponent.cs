using Infrastructure.Component.Shared.Storage.Dragonfly;
using Infrastructure.Component.Shared.Storage.TiDB;
using Infrastructure.Extension;
using Infrastructure.WebApplication.Resource.Dotnet;
using Infrastructure.WebApplication.Resource.OpenTelemetryOperator;
using Infrastructure.WebApplication.Resource.Promtail;
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
        private readonly OpenTelemetryOperatorResource _openTelemetryOperatorResource;
        private readonly PromtailResource _promtailResource;

        public WebApplicationComponent(ILogger<WebApplicationComponent> logger, Config config, 
            TiDBComponent tiDbComponent, 
            DotnetApplicationResource dotnetApplicationResource,
            OpenTelemetryOperatorResource openTelemetryOperatorResource,
            PromtailResource promtailResource)
        {
            _logger = logger;
            _config = config;
            _dotnetApplicationResource = dotnetApplicationResource;
            _openTelemetryOperatorResource = openTelemetryOperatorResource;
            _promtailResource = promtailResource;
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
            _ = @namespace.Metadata.Apply(x => x.Name);

            _openTelemetryOperatorResource.Apply();
            _promtailResource.Apply();
            _dotnetApplicationResource.Apply();

            return string.Empty;
        }
    }
}