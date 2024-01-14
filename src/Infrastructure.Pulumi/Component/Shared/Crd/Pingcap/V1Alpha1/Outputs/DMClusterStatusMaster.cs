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
    public sealed class DMClusterStatusMaster
    {
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterStatusMasterConditions> Conditions;
        public readonly ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterStatusMasterFailureMembers> FailureMembers;
        public readonly string Image;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterStatusMasterLeader Leader;
        public readonly ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterStatusMasterMembers> Members;
        public readonly string Phase;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterStatusMasterStatefulSet StatefulSet;
        public readonly bool Synced;
        public readonly ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterStatusMasterUnjoinedMembers> UnjoinedMembers;
        public readonly ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterStatusMasterVolumes> Volumes;

        [OutputConstructor]
        private DMClusterStatusMaster(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterStatusMasterConditions> conditions,

            ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterStatusMasterFailureMembers> failureMembers,

            string image,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterStatusMasterLeader leader,

            ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterStatusMasterMembers> members,

            string phase,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterStatusMasterStatefulSet statefulSet,

            bool synced,

            ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterStatusMasterUnjoinedMembers> unjoinedMembers,

            ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterStatusMasterVolumes> volumes)
        {
            Conditions = conditions;
            FailureMembers = failureMembers;
            Image = image;
            Leader = leader;
            Members = members;
            Phase = phase;
            StatefulSet = statefulSet;
            Synced = synced;
            UnjoinedMembers = unjoinedMembers;
            Volumes = volumes;
        }
    }
}
