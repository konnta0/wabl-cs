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
    public sealed class BackupSpecAffinityPodantiaffinity
    {
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecAffinityPodantiaffinityPreferredduringschedulingignoredduringexecution> PreferredDuringSchedulingIgnoredDuringExecution;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecAffinityPodantiaffinityRequiredduringschedulingignoredduringexecution> RequiredDuringSchedulingIgnoredDuringExecution;

        [OutputConstructor]
        private BackupSpecAffinityPodantiaffinity(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecAffinityPodantiaffinityPreferredduringschedulingignoredduringexecution> preferredDuringSchedulingIgnoredDuringExecution,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecAffinityPodantiaffinityRequiredduringschedulingignoredduringexecution> requiredDuringSchedulingIgnoredDuringExecution)
        {
            PreferredDuringSchedulingIgnoredDuringExecution = preferredDuringSchedulingIgnoredDuringExecution;
            RequiredDuringSchedulingIgnoredDuringExecution = requiredDuringSchedulingIgnoredDuringExecution;
        }
    }
}
