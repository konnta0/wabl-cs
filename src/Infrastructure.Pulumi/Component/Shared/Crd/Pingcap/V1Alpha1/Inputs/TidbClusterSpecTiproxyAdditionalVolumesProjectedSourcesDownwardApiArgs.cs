// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecTiproxyAdditionalVolumesProjectedSourcesDownwardApiArgs : global::Pulumi.ResourceArgs
    {
        [Input("items")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesProjectedSourcesDownwardApiItemsArgs>? _items;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesProjectedSourcesDownwardApiItemsArgs> Items
        {
            get => _items ?? (_items = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesProjectedSourcesDownwardApiItemsArgs>());
            set => _items = value;
        }

        public TidbClusterSpecTiproxyAdditionalVolumesProjectedSourcesDownwardApiArgs()
        {
        }
        public static new TidbClusterSpecTiproxyAdditionalVolumesProjectedSourcesDownwardApiArgs Empty => new TidbClusterSpecTiproxyAdditionalVolumesProjectedSourcesDownwardApiArgs();
    }
}
