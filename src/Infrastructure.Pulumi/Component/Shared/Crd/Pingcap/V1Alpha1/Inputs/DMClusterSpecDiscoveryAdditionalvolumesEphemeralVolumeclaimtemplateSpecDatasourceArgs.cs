// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class DMClusterSpecDiscoveryAdditionalVolumesEphemeralVolumeClaimTemplateSpecDataSourceArgs : global::Pulumi.ResourceArgs
    {
        [Input("apiGroup")]
        public Input<string>? ApiGroup { get; set; }

        [Input("kind", required: true)]
        public Input<string> Kind { get; set; } = null!;

        [Input("name", required: true)]
        public Input<string> Name { get; set; } = null!;

        public DMClusterSpecDiscoveryAdditionalVolumesEphemeralVolumeClaimTemplateSpecDataSourceArgs()
        {
        }
        public static new DMClusterSpecDiscoveryAdditionalVolumesEphemeralVolumeClaimTemplateSpecDataSourceArgs Empty => new DMClusterSpecDiscoveryAdditionalVolumesEphemeralVolumeClaimTemplateSpecDataSourceArgs();
    }
}
