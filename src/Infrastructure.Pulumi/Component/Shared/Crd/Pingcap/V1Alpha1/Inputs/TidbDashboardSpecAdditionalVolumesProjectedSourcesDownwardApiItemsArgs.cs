// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbDashboardSpecAdditionalVolumesProjectedSourcesDownwardApiItemsArgs : global::Pulumi.ResourceArgs
    {
        [Input("fieldRef")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalVolumesProjectedSourcesDownwardApiItemsFieldRefArgs>? FieldRef { get; set; }

        [Input("mode")]
        public Input<int>? Mode { get; set; }

        [Input("path", required: true)]
        public Input<string> Path { get; set; } = null!;

        [Input("resourceFieldRef")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalVolumesProjectedSourcesDownwardApiItemsResourceFieldRefArgs>? ResourceFieldRef { get; set; }

        public TidbDashboardSpecAdditionalVolumesProjectedSourcesDownwardApiItemsArgs()
        {
        }
        public static new TidbDashboardSpecAdditionalVolumesProjectedSourcesDownwardApiItemsArgs Empty => new TidbDashboardSpecAdditionalVolumesProjectedSourcesDownwardApiItemsArgs();
    }
}
