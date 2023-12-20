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
    public sealed class TidbClusterStatusTikv
    {
        public readonly bool BootStrapped;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTikvConditions> Conditions;
        public readonly ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTikvEvictleader> EvictLeader;
        public readonly string FailoverUID;
        public readonly ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTikvFailurestores> FailureStores;
        public readonly string Image;
        public readonly ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTikvPeerstores> PeerStores;
        public readonly string Phase;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTikvStatefulset StatefulSet;
        public readonly ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTikvStores> Stores;
        public readonly bool Synced;
        public readonly ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTikvTombstonestores> TombstoneStores;
        public readonly ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTikvVolumes> Volumes;

        [OutputConstructor]
        private TidbClusterStatusTikv(
            bool bootStrapped,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTikvConditions> conditions,

            ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTikvEvictleader> evictLeader,

            string failoverUID,

            ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTikvFailurestores> failureStores,

            string image,

            ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTikvPeerstores> peerStores,

            string phase,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTikvStatefulset statefulSet,

            ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTikvStores> stores,

            bool synced,

            ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTikvTombstonestores> tombstoneStores,

            ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterStatusTikvVolumes> volumes)
        {
            BootStrapped = bootStrapped;
            Conditions = conditions;
            EvictLeader = evictLeader;
            FailoverUID = failoverUID;
            FailureStores = failureStores;
            Image = image;
            PeerStores = peerStores;
            Phase = phase;
            StatefulSet = statefulSet;
            Stores = stores;
            Synced = synced;
            TombstoneStores = tombstoneStores;
            Volumes = volumes;
        }
    }
}