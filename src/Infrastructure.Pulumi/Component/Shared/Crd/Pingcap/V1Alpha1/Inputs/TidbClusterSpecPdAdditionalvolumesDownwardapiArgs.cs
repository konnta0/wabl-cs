// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecPdAdditionalVolumesDownwardApiArgs : global::Pulumi.ResourceArgs
    {
        [Input("defaultMode")]
        public Input<int>? DefaultMode { get; set; }

        [Input("items")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPdAdditionalVolumesDownwardApiItemsArgs>? _items;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPdAdditionalVolumesDownwardApiItemsArgs> Items
        {
            get => _items ?? (_items = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPdAdditionalVolumesDownwardApiItemsArgs>());
            set => _items = value;
        }

        public TidbClusterSpecPdAdditionalVolumesDownwardApiArgs()
        {
        }
        public static new TidbClusterSpecPdAdditionalVolumesDownwardApiArgs Empty => new TidbClusterSpecPdAdditionalVolumesDownwardApiArgs();
    }
}
