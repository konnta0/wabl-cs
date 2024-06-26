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
    public sealed class TidbClusterStatusTiproxy
    {
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTiproxyConditions> Conditions;
        public readonly ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTiproxyMembers> Members;
        public readonly string Phase;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTiproxyStatefulSet StatefulSet;
        public readonly bool Synced;
        public readonly ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTiproxyVolumes> Volumes;

        [OutputConstructor]
        private TidbClusterStatusTiproxy(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTiproxyConditions> conditions,

            ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTiproxyMembers> members,

            string phase,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTiproxyStatefulSet statefulSet,

            bool synced,

            ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTiproxyVolumes> volumes)
        {
            Conditions = conditions;
            Members = members;
            Phase = phase;
            StatefulSet = statefulSet;
            Synced = synced;
            Volumes = volumes;
        }
    }
}
