using System.Collections.Immutable;
using Pulumi;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Tekton
{
    public class TektonTaskRun
    {
        private readonly Config _config;

        public TektonTaskRun(Config config)
        {
            _config = config;
        }

        public void Apply()
        {
            _ = new ConfigFile("tekton-pipeline-task-run-hello-world", new ConfigFileArgs
            {
                File = "./Component/Shared/Tekton/Yaml/TaskRun/hello-world-task-run.yaml",
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