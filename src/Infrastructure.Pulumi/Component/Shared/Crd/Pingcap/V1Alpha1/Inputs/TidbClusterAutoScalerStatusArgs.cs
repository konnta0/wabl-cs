// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterAutoScalerStatusArgs : global::Pulumi.ResourceArgs
    {
        [Input("tidb")]
        private InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterAutoScalerStatusTidbArgs>? _tidb;
        public InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterAutoScalerStatusTidbArgs> Tidb
        {
            get => _tidb ?? (_tidb = new InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterAutoScalerStatusTidbArgs>());
            set => _tidb = value;
        }

        [Input("tikv")]
        private InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterAutoScalerStatusTikvArgs>? _tikv;
        public InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterAutoScalerStatusTikvArgs> Tikv
        {
            get => _tikv ?? (_tikv = new InputMap<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterAutoScalerStatusTikvArgs>());
            set => _tikv = value;
        }

        public TidbClusterAutoScalerStatusArgs()
        {
        }
        public static new TidbClusterAutoScalerStatusArgs Empty => new TidbClusterAutoScalerStatusArgs();
    }
}
