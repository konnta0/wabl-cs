// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterStatusArgs : global::Pulumi.ResourceArgs
    {
        [Input("auto-scaler")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusAutoScalerArgs>? AutoScaler { get; set; }

        [Input("clusterID")]
        public Input<string>? ClusterID { get; set; }

        [Input("conditions")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusConditionsArgs>? _conditions;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusConditionsArgs> Conditions
        {
            get => _conditions ?? (_conditions = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusConditionsArgs>());
            set => _conditions = value;
        }

        [Input("pd")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusPdArgs>? Pd { get; set; }

        [Input("pump")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusPumpArgs>? Pump { get; set; }

        [Input("ticdc")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTicdcArgs>? Ticdc { get; set; }

        [Input("tidb")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTidbArgs>? Tidb { get; set; }

        [Input("tiflash")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTiflashArgs>? Tiflash { get; set; }

        [Input("tikv")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTikvArgs>? Tikv { get; set; }

        [Input("tiproxy")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterStatusTiproxyArgs>? Tiproxy { get; set; }

        public TidbClusterStatusArgs()
        {
        }
        public static new TidbClusterStatusArgs Empty => new TidbClusterStatusArgs();
    }
}
