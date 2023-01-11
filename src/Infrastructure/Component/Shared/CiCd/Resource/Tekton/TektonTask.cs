using System.Collections.Immutable;
using Pulumi;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.CI_CD.Resource.Tekton
{
    public class TektonTask
    {
        private readonly Config _config;

        public TektonTask(Config config)
        {
            _config = config;
        }

        public void Apply()
        {
            var tasks = new[]
            {
                "push-image",
                "hello-world-task",
                "git-clone",
                "buildah",
                "unit-test",
                "curl"
            };
            
            foreach (var task in tasks)
            {
                _ = new ConfigFile($"tekton-pipeline-task-{task}", new ConfigFileArgs
                {
                    File = $"./CI_CD/Resource/Tekton/Yaml/Task/{task}.yaml",
                    Transformations =
                    {
                        TransformNamespace
                    }
                });
            }
        }
        
        private ImmutableDictionary<string, object> TransformNamespace(ImmutableDictionary<string, object> obj, CustomResourceOptions opts)
        {
            var metadata = (ImmutableDictionary<string, object>)obj["metadata"];
            if (!metadata.ContainsKey("namespace")) return obj;
            return obj.SetItem("metadata", metadata.SetItem("namespace", "tekton-pipelines"));
        }
    }
}