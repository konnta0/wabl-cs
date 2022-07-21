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
            _ = new ConfigFile("tekton-pipeline-task-push-image-config", new ConfigFileArgs
            {
                File = "./CI_CD/Resource/Tekton/Yaml/Task/push-image.yaml",
                Transformations =
                {
                    TransformNamespace
                }
            });
            _ = new ConfigFile("tekton-pipeline-task-hello-world", new ConfigFileArgs
            {
                File = "./CI_CD/Resource/Tekton/Yaml/Task/hello-world-task.yaml",
                Transformations =
                {
                    TransformNamespace
                }
            });
            _ = new ConfigFile("tekton-pipeline-task-git-clone", new ConfigFileArgs
            {
                File = "./CI_CD/Resource/Tekton/Yaml/Task/git-clone.yaml",
                Transformations =
                {
                    TransformNamespace
                }
            });
        }
        
        private ImmutableDictionary<string, object> TransformNamespace(ImmutableDictionary<string, object> obj, CustomResourceOptions opts)
        {
            var metadata = (ImmutableDictionary<string, object>)obj["metadata"];
            if (!metadata.ContainsKey("namespace")) return obj;
            return obj.SetItem("metadata", metadata.SetItem("namespace", "tekton-pipelines"));
        }
    }
}