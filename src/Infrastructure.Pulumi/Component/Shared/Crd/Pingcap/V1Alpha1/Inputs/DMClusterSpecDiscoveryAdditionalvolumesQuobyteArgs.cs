// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class DMClusterSpecDiscoveryAdditionalVolumesQuobyteArgs : global::Pulumi.ResourceArgs
    {
        [Input("group")]
        public Input<string>? Group { get; set; }

        [Input("readOnly")]
        public Input<bool>? ReadOnly { get; set; }

        [Input("registry", required: true)]
        public Input<string> Registry { get; set; } = null!;

        [Input("tenant")]
        public Input<string>? Tenant { get; set; }

        [Input("user")]
        public Input<string>? User { get; set; }

        [Input("volume", required: true)]
        public Input<string> Volume { get; set; } = null!;

        public DMClusterSpecDiscoveryAdditionalVolumesQuobyteArgs()
        {
        }
        public static new DMClusterSpecDiscoveryAdditionalVolumesQuobyteArgs Empty => new DMClusterSpecDiscoveryAdditionalVolumesQuobyteArgs();
    }
}
