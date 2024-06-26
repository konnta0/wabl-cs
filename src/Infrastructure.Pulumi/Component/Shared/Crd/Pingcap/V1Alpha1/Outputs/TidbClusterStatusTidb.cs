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
    public sealed class TidbClusterStatusTidb
    {
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTidbConditions> Conditions;
        public readonly ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTidbFailureMembers> FailureMembers;
        public readonly string Image;
        public readonly ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTidbMembers> Members;
        public readonly bool PasswordInitialized;
        public readonly string Phase;
        public readonly int ResignDDLOwnerRetryCount;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTidbStatefulSet StatefulSet;
        public readonly bool VolReplaceInProgress;
        public readonly ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTidbVolumes> Volumes;

        [OutputConstructor]
        private TidbClusterStatusTidb(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTidbConditions> conditions,

            ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTidbFailureMembers> failureMembers,

            string image,

            ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTidbMembers> members,

            bool passwordInitialized,

            string phase,

            int resignDDLOwnerRetryCount,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTidbStatefulSet statefulSet,

            bool volReplaceInProgress,

            ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTidbVolumes> volumes)
        {
            Conditions = conditions;
            FailureMembers = failureMembers;
            Image = image;
            Members = members;
            PasswordInitialized = passwordInitialized;
            Phase = phase;
            ResignDDLOwnerRetryCount = resignDDLOwnerRetryCount;
            StatefulSet = statefulSet;
            VolReplaceInProgress = volReplaceInProgress;
            Volumes = volumes;
        }
    }
}
