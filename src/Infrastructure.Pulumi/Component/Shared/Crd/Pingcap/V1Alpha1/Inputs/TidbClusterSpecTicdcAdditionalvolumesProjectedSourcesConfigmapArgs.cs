// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecTicdcAdditionalVolumesProjectedSourcesConfigMapArgs : global::Pulumi.ResourceArgs
    {
        [Input("items")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTicdcAdditionalVolumesProjectedSourcesConfigMapItemsArgs>? _items;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTicdcAdditionalVolumesProjectedSourcesConfigMapItemsArgs> Items
        {
            get => _items ?? (_items = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTicdcAdditionalVolumesProjectedSourcesConfigMapItemsArgs>());
            set => _items = value;
        }

        [Input("name")]
        public Input<string>? Name { get; set; }

        [Input("optional")]
        public Input<bool>? Optional { get; set; }

        public TidbClusterSpecTicdcAdditionalVolumesProjectedSourcesConfigMapArgs()
        {
        }
        public static new TidbClusterSpecTicdcAdditionalVolumesProjectedSourcesConfigMapArgs Empty => new TidbClusterSpecTicdcAdditionalVolumesProjectedSourcesConfigMapArgs();
    }
}
