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
    public sealed class TidbDashboardSpecAdditionalVolumesProjectedSourcesDownwardApiItems
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalVolumesProjectedSourcesDownwardApiItemsFieldRef FieldRef;
        public readonly int Mode;
        public readonly string Path;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalVolumesProjectedSourcesDownwardApiItemsResourceFieldRef ResourceFieldRef;

        [OutputConstructor]
        private TidbDashboardSpecAdditionalVolumesProjectedSourcesDownwardApiItems(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalVolumesProjectedSourcesDownwardApiItemsFieldRef fieldRef,

            int mode,

            string path,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalVolumesProjectedSourcesDownwardApiItemsResourceFieldRef resourceFieldRef)
        {
            FieldRef = fieldRef;
            Mode = mode;
            Path = path;
            ResourceFieldRef = resourceFieldRef;
        }
    }
}
