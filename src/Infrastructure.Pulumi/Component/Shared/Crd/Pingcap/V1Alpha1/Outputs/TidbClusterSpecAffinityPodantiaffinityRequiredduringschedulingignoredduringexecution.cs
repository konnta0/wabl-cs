// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1
{

    [OutputType]
    public sealed class TidbClusterSpecAffinityPodAntiAffinityRequiredDuringSchedulingIgnoredDuringExecution
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecAffinityPodAntiAffinityRequiredDuringSchedulingIgnoredDuringExecutionLabelSelector LabelSelector;
        public readonly ImmutableArray<string> Namespaces;
        public readonly string TopologyKey;

        [OutputConstructor]
        private TidbClusterSpecAffinityPodAntiAffinityRequiredDuringSchedulingIgnoredDuringExecution(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecAffinityPodAntiAffinityRequiredDuringSchedulingIgnoredDuringExecutionLabelSelector labelSelector,

            ImmutableArray<string> namespaces,

            string topologyKey)
        {
            LabelSelector = labelSelector;
            Namespaces = namespaces;
            TopologyKey = topologyKey;
        }
    }
}
