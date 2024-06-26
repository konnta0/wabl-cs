// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterStatusTikvArgs : global::Pulumi.ResourceArgs
    {
        [Input("bootStrapped")]
        public Input<bool>? BootStrapped { get; set; }

        [Input("conditions")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvConditionsArgs>? _conditions;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvConditionsArgs> Conditions
        {
            get => _conditions ?? (_conditions = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvConditionsArgs>());
            set => _conditions = value;
        }

        [Input("evictLeader")]
        private InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvEvictLeaderArgs>? _evictLeader;
        public InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvEvictLeaderArgs> EvictLeader
        {
            get => _evictLeader ?? (_evictLeader = new InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvEvictLeaderArgs>());
            set => _evictLeader = value;
        }

        [Input("failoverUID")]
        public Input<string>? FailoverUID { get; set; }

        [Input("failureStores")]
        private InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvFailureStoresArgs>? _failureStores;
        public InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvFailureStoresArgs> FailureStores
        {
            get => _failureStores ?? (_failureStores = new InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvFailureStoresArgs>());
            set => _failureStores = value;
        }

        [Input("image")]
        public Input<string>? Image { get; set; }

        [Input("peerStores")]
        private InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvPeerStoresArgs>? _peerStores;
        public InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvPeerStoresArgs> PeerStores
        {
            get => _peerStores ?? (_peerStores = new InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvPeerStoresArgs>());
            set => _peerStores = value;
        }

        [Input("phase")]
        public Input<string>? Phase { get; set; }

        [Input("statefulSet")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvStatefulSetArgs>? StatefulSet { get; set; }

        [Input("stores")]
        private InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvStoresArgs>? _stores;
        public InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvStoresArgs> Stores
        {
            get => _stores ?? (_stores = new InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvStoresArgs>());
            set => _stores = value;
        }

        [Input("synced")]
        public Input<bool>? Synced { get; set; }

        [Input("tombstoneStores")]
        private InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvTombstoneStoresArgs>? _tombstoneStores;
        public InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvTombstoneStoresArgs> TombstoneStores
        {
            get => _tombstoneStores ?? (_tombstoneStores = new InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvTombstoneStoresArgs>());
            set => _tombstoneStores = value;
        }

        [Input("volReplaceInProgress")]
        public Input<bool>? VolReplaceInProgress { get; set; }

        [Input("volumes")]
        private InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvVolumesArgs>? _volumes;
        public InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvVolumesArgs> Volumes
        {
            get => _volumes ?? (_volumes = new InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvVolumesArgs>());
            set => _volumes = value;
        }

        public TidbClusterStatusTikvArgs()
        {
        }
        public static new TidbClusterStatusTikvArgs Empty => new TidbClusterStatusTikvArgs();
    }
}
