using System.Collections.Immutable;
using Pulumi;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Tekton.TaskRun
{
    public class TektonTaskRunComponent : IComponent<TektonTaskRunComponentInput, TektonTaskRunComponentOutput>
    {
        private readonly Config _config;

        public TektonTaskRunComponent(Config config)
        {
            _config = config;
        }
        
        public TektonTaskRunComponentOutput Apply(TektonTaskRunComponentInput input)
        {
            var ns = input.Namespace.Metadata.Apply(x => x.Name);
            ImmutableDictionary<string, object> TransformNamespace(ImmutableDictionary<string, object> obj,
                CustomResourceOptions opts)
            {
                var metadata = (ImmutableDictionary<string, object>)obj["metadata"];
                if (!metadata.ContainsKey("namespace")) return obj;
                return obj.SetItem("metadata", metadata.SetItem("namespace", ns));
            }

            _ = new ConfigFile("tekton-pipeline-task-run-hello-world", new ConfigFileArgs
            {
                File = "./Component/Shared/Tekton/TaskRun/Yaml/hello-world-task-run.yaml",
                Transformations =
                {
                    TransformNamespace
                }
            }, new ComponentResourceOptions {DependsOn = input.Namespace});
            return new TektonTaskRunComponentOutput();
        }
    }
}