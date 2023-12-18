using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Pulumi.VersionControlSystem.Resource.GiLab
{
    public class GitLabResource
    {
        private readonly Config _config;

        public GitLabResource(Config config)
        {
            _config = config;
        }

        public Output<string> Apply(Input<string> @namespace)
        {
            _ = new ConfigFile("certificate-gitlab", new ConfigFileArgs
            {
                File = "./Certificate/Resource/Yaml/gitlab.yaml",
                Transformations =
                {
                    (ImmutableDictionary<string, object> obj, CustomResourceOptions opts) =>
                    {
                        var metadata = (ImmutableDictionary<string, object>)obj["metadata"];
                        if (!metadata.ContainsKey("namespace")) return obj;
                        return obj.SetItem("metadata", metadata.SetItem("namespace", @namespace));
                    }
                }
            });

            //ref: https://gitlab.com/gitlab-org/charts/gitlab/blob/master/values.yaml
            var values = new Dictionary<string, object>
            {
                ["global"] = new Dictionary<string, object>
                {
                    ["hosts"] = new Dictionary<string, object>
                    {
                        ["domain"] = "gitlab.vcs.test"
                    },
                    ["ingress"] = new Dictionary<string, object>
                    {
                        ["configureCertmanager"] = false,
                        ["apiVersion"] = "networking.k8s.io/v1",
                        ["tls"] = new Dictionary<string, object>
                        {
                            ["enabled"] = true,
                            ["secretName"] = "gitlab-certificate"
                        }
                    }
                },
                ["certmanager"] = new Dictionary<string, object>
                {
                    ["installCRDs"] = false,
                    ["install"] = false,
                    ["rbac"] = new Dictionary<string, object>
                    {
                        ["create"] = false
                    }
                }
            };
            _ = new Release("gitlab", new ReleaseArgs
            {
                Chart = "gitlab",
                //   helm search repo -l gitlab/gitlab | head -n 10
                // NAME                 	CHART VERSION	APP VERSION	DESCRIPTION
                // gitlab/gitlab        	6.2.1        	15.2.1     	The One DevOps Platform
                // gitlab/gitlab        	6.2.0        	15.2.0     	The One DevOps Platform
                // gitlab/gitlab        	6.1.4        	15.1.4     	The One DevOps Platform
                // gitlab/gitlab        	6.1.3        	15.1.3     	The One DevOps Platform
                // gitlab/gitlab        	6.1.2        	15.1.2     	The One DevOps Platform
                // gitlab/gitlab        	6.1.1        	15.1.1     	The One DevOps Platform
                // gitlab/gitlab        	6.1.0        	15.1.0     	The One DevOps Platform
                // gitlab/gitlab        	6.0.5        	15.0.5     	The One DevOps Platform
                // gitlab/gitlab        	6.0.4        	15.0.4     	The One DevOps Platform
                Version = "6.2.1",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://charts.gitlab.io/"
                },
                CreateNamespace = false,
                Atomic = true,
                Values = values,
                Namespace = @namespace,
                Timeout = 60 * 10
            });
            return Output<string>.Create(Task.FromResult("gitlab.vcs.test"));
        }
    }
}