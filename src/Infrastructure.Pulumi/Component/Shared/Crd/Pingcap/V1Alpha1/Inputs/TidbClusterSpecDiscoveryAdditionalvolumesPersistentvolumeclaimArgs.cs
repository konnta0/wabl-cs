// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecDiscoveryAdditionalVolumesPersistentVolumeClaimArgs : global::Pulumi.ResourceArgs
    {
        [Input("claimName", required: true)]
        public Input<string> ClaimName { get; set; } = null!;

        [Input("readOnly")]
        public Input<bool>? ReadOnly { get; set; }

        public TidbClusterSpecDiscoveryAdditionalVolumesPersistentVolumeClaimArgs()
        {
        }
        public static new TidbClusterSpecDiscoveryAdditionalVolumesPersistentVolumeClaimArgs Empty => new TidbClusterSpecDiscoveryAdditionalVolumesPersistentVolumeClaimArgs();
    }
}
