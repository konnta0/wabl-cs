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
    public sealed class TidbClusterSpecTiflashAdditionalVolumesProjectedSourcesDownwardApiItems
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesProjectedSourcesDownwardApiItemsFieldRef FieldRef;
        public readonly int Mode;
        public readonly string Path;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesProjectedSourcesDownwardApiItemsResourceFieldRef ResourceFieldRef;

        [OutputConstructor]
        private TidbClusterSpecTiflashAdditionalVolumesProjectedSourcesDownwardApiItems(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesProjectedSourcesDownwardApiItemsFieldRef fieldRef,

            int mode,

            string path,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesProjectedSourcesDownwardApiItemsResourceFieldRef resourceFieldRef)
        {
            FieldRef = fieldRef;
            Mode = mode;
            Path = path;
            ResourceFieldRef = resourceFieldRef;
        }
    }
}
