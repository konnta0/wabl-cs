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
    public sealed class RestoreSpecAffinity
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecAffinityNodeaffinity NodeAffinity;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecAffinityPodaffinity PodAffinity;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecAffinityPodantiaffinity PodAntiAffinity;

        [OutputConstructor]
        private RestoreSpecAffinity(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecAffinityNodeaffinity nodeAffinity,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecAffinityPodaffinity podAffinity,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecAffinityPodantiaffinity podAntiAffinity)
        {
            NodeAffinity = nodeAffinity;
            PodAffinity = podAffinity;
            PodAntiAffinity = podAntiAffinity;
        }
    }
}
