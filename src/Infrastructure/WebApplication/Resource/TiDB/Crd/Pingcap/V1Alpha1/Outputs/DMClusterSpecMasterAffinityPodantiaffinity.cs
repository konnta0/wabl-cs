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
    public sealed class DMClusterSpecMasterAffinityPodantiaffinity
    {
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecMasterAffinityPodantiaffinityPreferredduringschedulingignoredduringexecution> PreferredDuringSchedulingIgnoredDuringExecution;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecMasterAffinityPodantiaffinityRequiredduringschedulingignoredduringexecution> RequiredDuringSchedulingIgnoredDuringExecution;

        [OutputConstructor]
        private DMClusterSpecMasterAffinityPodantiaffinity(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecMasterAffinityPodantiaffinityPreferredduringschedulingignoredduringexecution> preferredDuringSchedulingIgnoredDuringExecution,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecMasterAffinityPodantiaffinityRequiredduringschedulingignoredduringexecution> requiredDuringSchedulingIgnoredDuringExecution)
        {
            PreferredDuringSchedulingIgnoredDuringExecution = preferredDuringSchedulingIgnoredDuringExecution;
            RequiredDuringSchedulingIgnoredDuringExecution = requiredDuringSchedulingIgnoredDuringExecution;
        }
    }
}