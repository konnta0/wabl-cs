using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Types.Inputs.Networking.V1;

namespace Infrastructure.Observability.Resource
{
    public class Ingress
    {
        private readonly ILogger<Ingress> _logger;

        public Ingress(ILogger<Ingress> logger)
        {
            _logger = logger;
        }

        public void Apply(Input<string> name)
        {
            var ingress = new Pulumi.Kubernetes.Networking.V1.Ingress("grafana-ingress", new IngressArgs
            {
                ApiVersion = "networking.k8s.io/v1",
                Metadata = new ObjectMetaArgs
                {
                    Name = "nginx-ingress",
                    Annotations = new InputMap<string>
                    {
                        { "kubernetes.io/ingress.class", "nginx" }
                    },
                    Namespace = Define.Namespace
                },
                Spec = new IngressSpecArgs
                {
                    IngressClassName = "nginx",
                    Rules = new List<IngressRuleArgs>
                    {
                        new IngressRuleArgs
                        {
                            Host = "o11y.grafana.test",
                            Http = new HTTPIngressRuleValueArgs
                            {
                                Paths = new HTTPIngressPathArgs
                                {
                                    Path = "/",
                                    PathType = "Prefix",
                                    Backend = new IngressBackendArgs
                                    {
                                        Service = new IngressServiceBackendArgs
                                        {
                                            Name = name,
                                            Port = new ServiceBackendPortArgs { Number = 3000 }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
        }
    }
}