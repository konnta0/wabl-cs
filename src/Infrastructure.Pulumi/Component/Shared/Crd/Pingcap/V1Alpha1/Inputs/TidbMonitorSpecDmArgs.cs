// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbMonitorSpecDmArgs : global::Pulumi.ResourceArgs
    {
        [Input("clusters", required: true)]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbMonitorSpecDmClustersArgs>? _clusters;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbMonitorSpecDmClustersArgs> Clusters
        {
            get => _clusters ?? (_clusters = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbMonitorSpecDmClustersArgs>());
            set => _clusters = value;
        }

        [Input("initializer", required: true)]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbMonitorSpecDmInitializerArgs> Initializer { get; set; } = null!;

        public TidbMonitorSpecDmArgs()
        {
        }
        public static new TidbMonitorSpecDmArgs Empty => new TidbMonitorSpecDmArgs();
    }
}
