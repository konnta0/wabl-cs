// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class DMClusterSpecDiscoveryAffinityPodAffinityPreferredDuringSchedulingIgnoredDuringExecutionArgs : global::Pulumi.ResourceArgs
    {
        [Input("podAffinityTerm", required: true)]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAffinityPodAffinityPreferredDuringSchedulingIgnoredDuringExecutionPodAffinityTermArgs> PodAffinityTerm { get; set; } = null!;

        [Input("weight", required: true)]
        public Input<int> Weight { get; set; } = null!;

        public DMClusterSpecDiscoveryAffinityPodAffinityPreferredDuringSchedulingIgnoredDuringExecutionArgs()
        {
        }
        public static new DMClusterSpecDiscoveryAffinityPodAffinityPreferredDuringSchedulingIgnoredDuringExecutionArgs Empty => new DMClusterSpecDiscoveryAffinityPodAffinityPreferredDuringSchedulingIgnoredDuringExecutionArgs();
    }
}
