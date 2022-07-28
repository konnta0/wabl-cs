using System.Collections.Generic;
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
            _ = new Pulumi.Kubernetes.Core.V1.Secret("tekton-pipeline-secret-container-registry", new SecretArgs
            {
                Type = "kubernetes.io/basic-auth",
                Immutable = true,
                StringData = new Dictionary<string, string>
                {
                    ["username"] = "admin",
                    ["password"] = "Harbor12345"
                },
                Metadata = new ObjectMetaArgs
                {
                    Name = "tekton-pipeline-secret-for-container-registry",
                    Namespace = "tekton-pipelines",
                    Annotations = new Dictionary<string, string>
                    {
                        // https://tekton.dev/vault/pipelines-v0.16.3/auth/#configuring-basic-auth-authentication-for-docker
                        ["tekton.dev/docker-0"] = "core.harbor.cr.test"
                    }
                }
            });
        }
    }
}