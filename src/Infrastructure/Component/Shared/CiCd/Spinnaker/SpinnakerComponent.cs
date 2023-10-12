using System.Collections.Immutable;
using Pulumi;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Spinnaker
{
    public class SpinnakerComponent : IComponent<SpinnakerComponentInput, SpinnakerComponentOutput>
    {
        private readonly Config _config;

        public SpinnakerComponent(Config config)
        {
            _config = config;
        }

        public SpinnakerComponentOutput Apply(SpinnakerComponentInput input)
        {
            // TODO: crd2pulumi
            var accountsCrd = new ConfigFile("spinnaker-accounts-crd", new ConfigFileArgs
            {
                File =
                    "./Component/Shared/CiCd/Spinnaker/Yaml/spinnaker-operator/deploy/crds/spinnaker.io_spinnakeraccounts.yaml"
                
            }, new ComponentResourceOptions { DependsOn = { input.Namespace } }).Ready();

            var servicesCrd = new ConfigFile("spinnaker-services-crd", new ConfigFileArgs
            {
                File =
                    "./Component/Shared/CiCd/Spinnaker/Yaml/spinnaker-operator/deploy/crds/spinnaker.io_spinnakerservices.yaml"
            }, new ComponentResourceOptions { DependsOn = { input.Namespace } }).Ready();


            var components = new[]
            {
                "deployment",
                "role",
                "role_binding",
                "service_account"
            };

            foreach (var component in components)
            {
                new ConfigFile($"spinnaker-operator-basic-{component}", new ConfigFileArgs
                {
                    File =
                        $"./Component/Shared/CiCd/Spinnaker/Yaml/spinnaker-operator/deploy/operator/basic/{component}.yaml",
                    Transformations =
                    {
                        (ImmutableDictionary<string, object> obj, CustomResourceOptions opts) =>
                        {
                            var metadata = (ImmutableDictionary<string, object>)obj["metadata"];
                            if (!metadata.ContainsKey("namespace")) return obj;
                            return obj.SetItem("metadata", metadata.SetItem("namespace", input.Namespace));
                        }
                    }
                }, new ComponentResourceOptions { DependsOn = { accountsCrd, servicesCrd } }).Ready();
            }
            
            
            // use crd2pulumi to generate the following resources
            new ConfigFile($"spinnaker-operator-cluster-spinnakerservice", new ConfigFileArgs
            {
                File =
                    $"./Component/Shared/CiCd/Spinnaker/Yaml/spinnaker-operator/deploy/spinnaker/basic/spinnakerservice.yml",
                Transformations =
                {
                    // (ImmutableDictionary<string, object> obj, CustomResourceOptions opts) =>
                    // {
                    //     var metadata = (ImmutableDictionary<string, object>)obj["metadata"];
                    //     if (!metadata.ContainsKey("namespace")) return obj;
                    //     return obj.SetItem("metadata", metadata.SetItem("namespace", input.Namespace));
                    // }
                }
            }).Ready();
            return new SpinnakerComponentOutput();
        }
    }
}