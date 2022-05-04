using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Types.Inputs.Networking.V1;

namespace Infrastructure.Resource.Ingress
{
    public class IngressResource
    {
        private readonly ILogger<IngressResource> _logger;

        public IngressResource(ILogger<IngressResource> logger)
        {
            _logger = logger;
        }

        public void Apply()
        {
            var ingress = new Pulumi.Kubernetes.Networking.V1.Ingress("nginx-ingress", new IngressArgs
            {
                ApiVersion = "networking.k8s.io/v1",
                Metadata = new ObjectMetaArgs
                {
                    Name = "nginx-ingress",
                    Annotations = new InputMap<string>
                    {
                        {"kubernetes.io/ingress.class", "nginx"}
                    }
                },
                Spec = new IngressSpecArgs
                {
                    Rules = new List<IngressRuleArgs>
                    {
                        new IngressRuleArgs
                        {
                            Host = "core.harbor.domain",
                            Http = new HTTPIngressRuleValueArgs
                            {
                            }
                        }
                    }
                }
            });
            
        }
    }
}