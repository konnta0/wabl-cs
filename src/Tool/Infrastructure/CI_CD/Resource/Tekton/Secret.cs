using System.Collections.Generic;
using System.Text.Json;
using Pulumi;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;

namespace Infrastructure.CI_CD.Resource.Tekton
{
    public class Secret
    {
        public Secret()
        {
            
        }

        public void Apply()
        {
            var config = new Dictionary<string, object>
            {
                ["auths"] = new Dictionary<string, object>
                {
                    ["core.harbor.cr.test"] = new Dictionary<string, object>
                    {
                    }
                }
            };
            _ = new Pulumi.Kubernetes.Core.V1.Secret("tekton-pipeline-secret-container-registry", new SecretArgs
            {
                Type = "kubernetes.io/dockerconfigjson",
                Immutable = true,
                StringData = new Dictionary<string, string>
                {
                    [".dockerconfigjson"] = JsonSerializer.Serialize(config)
                },
                Metadata = new ObjectMetaArgs
                {
                    Name = "tekton-pipeline-secret-for-container-registry",
                    Namespace = "tekton-pipelines"
                }
            });
        }
    }
}