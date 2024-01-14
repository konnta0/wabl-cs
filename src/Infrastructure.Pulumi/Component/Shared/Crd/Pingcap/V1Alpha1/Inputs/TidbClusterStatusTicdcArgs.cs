// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterStatusTicdcArgs : global::Pulumi.ResourceArgs
    {
        [Input("captures")]
        private InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTicdcCapturesArgs>? _captures;
        public InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTicdcCapturesArgs> Captures
        {
            get => _captures ?? (_captures = new InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTicdcCapturesArgs>());
            set => _captures = value;
        }

        [Input("conditions")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTicdcConditionsArgs>? _conditions;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTicdcConditionsArgs> Conditions
        {
            get => _conditions ?? (_conditions = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTicdcConditionsArgs>());
            set => _conditions = value;
        }

        [Input("phase")]
        public Input<string>? Phase { get; set; }

        [Input("statefulSet")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTicdcStatefulSetArgs>? StatefulSet { get; set; }

        [Input("synced")]
        public Input<bool>? Synced { get; set; }

        [Input("volumes")]
        private InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTicdcVolumesArgs>? _volumes;
        public InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTicdcVolumesArgs> Volumes
        {
            get => _volumes ?? (_volumes = new InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTicdcVolumesArgs>());
            set => _volumes = value;
        }

        public TidbClusterStatusTicdcArgs()
        {
        }
        public static new TidbClusterStatusTicdcArgs Empty => new TidbClusterStatusTicdcArgs();
    }
}
